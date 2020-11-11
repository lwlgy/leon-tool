using LeonTools.Common;
using LeonTools.CustomerComponent;
using LeonTools.Model;
using LeonTools.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace LeonTools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView
    {

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private const int MY_HOTKEYID = 0x9999;
        private List<ToolItemComponent> toolItemList = new List<ToolItemComponent>();

        private string configPath;
        private string appConfigPath;
        private bool hasInited = false;
        private FileDropHandler MainPanelFileDroper; //全局的
        private FileDropHandler WindowFileDroper; //全局的

        public MainView()
        {
            Consts.MainView = this;
            InitializeComponent();
            this.SetSystemTray(BringToFront, HideToTaskbar);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            #region 不起作用
            MainPanelFileDroper = new FileDropHandler(MainPanel);
            WindowFileDroper = new FileDropHandler(this);
            #endregion
            configPath = Path.Combine(System.Windows.Forms.Application.StartupPath, "config.json");
            appConfigPath = Path.Combine(System.Windows.Forms.Application.StartupPath, "appConfig.json");
            if (File.Exists(configPath))
            {
                try
                {
                    List<ToolItemViewModel> list = PersistenceHelper.Load<List<ToolItemViewModel>>(configPath);
                    foreach (var item in list)
                    {
                        ToolItemComponent toolItemControl = new ToolItemComponent(item, this);
                        MainPanel.Children.Add(toolItemControl);
                        toolItemList.Add(toolItemControl);
                    }
                }
                catch (Exception exception)
                {
                    System.Windows.MessageBox.Show($"未能正确读取快捷方式文件({exception.Message})", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            if (File.Exists(appConfigPath))
            {
                try
                {
                    AppConfig appConfig = PersistenceHelper.Load<AppConfig>(appConfigPath);
                    if (appConfig.Width > 0 && appConfig.Height > 0)
                    {
                        Width = appConfig.Width;
                        Height = appConfig.Height;
                    }
                }
                catch (Exception exception)
                {
                    System.Windows.MessageBox.Show($"未能正确读取配置文件({exception.Message})", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            hasInited = true;
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            IntPtr handle = new WindowInteropHelper(this).Handle;
            RegisterHotKey(handle, MY_HOTKEYID, 0x0001, 0x45);

            HwndSource source = PresentationSource.FromVisual(this) as HwndSource;
            source.AddHook(WndProc);
        }

        IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handle)
        {
            if (wParam.ToInt32() == MY_HOTKEYID)
            {
                //全局快捷键要执行的命令
                if (Visibility != Visibility.Visible || WindowState != WindowState.Normal || !IsActive)
                {
                    BringToFront();
                }
                else
                {
                    HideToTaskbar();
                }
            }
            return IntPtr.Zero;
        }

        private void MainPanel_OnDragEnter(object sender, System.Windows.DragEventArgs e)
        {
            e.Effects = e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop) ? System.Windows.DragDropEffects.Link : System.Windows.DragDropEffects.None;
        }

        private void MainPanel_OnDrop(object sender, System.Windows.DragEventArgs e)
        {

            if (!e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop)) return;
            var strs = (string[])e.Data.GetData(System.Windows.DataFormats.FileDrop);
            if (strs == null || !strs.Any()) return;
            foreach (var str in strs)
            {
                var findItem = toolItemList.Find(i => i.GetToolItemViewModel() != null && i.GetToolItemViewModel().FileName == str);
                if (findItem != null)
                {
                    continue;
                }
                string realPath = FileHelper.GetFileRealPath(str);
                var toolItem = new ToolItemViewModel
                {
                    FileName = realPath,
                    Name = Path.GetFileNameWithoutExtension(str)
                };
                var icon = FileHelper.GetShortcurIcoFromFilePath(realPath);
                if (icon != null)
                {
                    toolItem.Icon = IconHelper.ToByte(icon);
                }
                ToolItemComponent toolItemControl = new ToolItemComponent(toolItem, this);
                MainPanel.Children.Add(toolItemControl);
                toolItemList.Add(toolItemControl);
            }
            Save();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            HideToTaskbar();
            e.Cancel = true;
        }

        private void Save()
        {
            List<ToolItemViewModel> list = toolItemList.Select(i => (ToolItemViewModel)i.DataContext).ToList();
            try
            {
                PersistenceHelper.Save(list, configPath);
            }
            catch (Exception exception)
            {
                System.Windows.MessageBox.Show($"未能正确写入配置文件({exception.Message})", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void HideToTaskbar()
        {
            ShowInTaskbar = false;
            Hide();
        }

        public void BringToFront()
        {
            ShowInTaskbar = true;
            Show();
            WindowState = WindowState.Normal;
            Activate();
            Focus();
        }

        public void RemoveToolItem(ToolItemComponent toolItem)
        {
            ToolItemComponent item = toolItemList.FirstOrDefault(i => i.Id == toolItem.Id);
            if (item != null)
            {
                MainPanel.Children.Remove(item);
                toolItemList.Remove(item);
                Save();
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (hasInited)
            {
                AppConfig appConfig = new AppConfig()
                {
                    Width = e.NewSize.Width,
                    Height = e.NewSize.Height
                };
                PersistenceHelper.Save(appConfig, appConfigPath);
            }
        }
    }
}
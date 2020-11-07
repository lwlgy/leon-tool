using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using LeonTools.Common;
using LeonTools.CustomerComponent;
using LeonTools.ViewModel;

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

        private const Int32 MY_HOTKEYID = 0x9999;
        private List<ToolItemComponent> toolItemList = new List<ToolItemComponent>();
        private NotifyIcon notifyIcon;
        private string configPath;

        public MainView()
        {
            InitializeComponent();

            this.notifyIcon = new NotifyIcon();
            this.notifyIcon.BalloonTipText = "快速启动工具";
            this.notifyIcon.ShowBalloonTip(2000);
            this.notifyIcon.Text = "快速启动工具";
            this.notifyIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath);
            this.notifyIcon.Visible = true;
            //打开菜单项
            System.Windows.Forms.MenuItem open = new System.Windows.Forms.MenuItem("打开");
            open.Click += new EventHandler(Show);
            //退出菜单项
            System.Windows.Forms.MenuItem exit = new System.Windows.Forms.MenuItem("关闭");
            exit.Click += new EventHandler(Close);
            //关联托盘控件
            System.Windows.Forms.MenuItem[] childen = new System.Windows.Forms.MenuItem[] { open, exit };
            notifyIcon.ContextMenu = new System.Windows.Forms.ContextMenu(childen);

            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler((o, e) =>
            {
                if (e.Button == MouseButtons.Left) this.Show(o, e);
            });
        }

        private void Show(object sender, EventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Visible;
            this.ShowInTaskbar = true;
            this.Activate();
        }

        private void Hide(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            this.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Close(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
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
            //Debug.WriteLine("hwnd:{0},msg:{1},wParam:{2},lParam{3}:,handle:{4}"
            //                ,hwnd,msg,wParam,lParam,handle);
            if (wParam.ToInt32() == MY_HOTKEYID)
            {
                //全局快捷键要执行的命令
                this.ShowInTaskbar = true;
                this.Show();
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
                var findItem = this.toolItemList.Find(i => i.GetToolItemViewModel() != null && i.GetToolItemViewModel().FileName == str);
                if (findItem != null)
                {
                    continue;
                }
                string realPath = FileHelper.GetFileRealPath(str);
                var toolItem = new ToolItemViewModel
                {
                    FileName = realPath,
                    Name = Path.GetFileNameWithoutExtension(realPath)
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
            this.Hide();
            e.Cancel = true;
        }

        private void Save()
        {
            List<ToolItemViewModel> list = this.toolItemList.Select(i => (ToolItemViewModel)i.DataContext).ToList();
            try
            {
                PersistenceHelper.Save(list, configPath);
            }
            catch (Exception exception)
            {
                System.Windows.MessageBox.Show($"未能正确写入配置文件({exception.Message})", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            configPath = Path.Combine(System.Windows.Forms.Application.StartupPath, "config.json");
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
                    System.Windows.MessageBox.Show($"未能正确载入配置文件({exception.Message})", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        public void RemoveToolItem(ToolItemComponent toolItem)
        {
            ToolItemComponent item = this.toolItemList.FirstOrDefault(i => i.Id == toolItem.Id);
            if (item != null)
            {
                MainPanel.Children.Remove(item);
                toolItemList.Remove(item);
                Save();
            }
        }
    }
}
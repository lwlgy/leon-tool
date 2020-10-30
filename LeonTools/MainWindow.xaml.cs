using System.IO;
using System.Linq;
using System.Windows;
using LeonTools.Common;
using LeonTools.Model;

namespace LeonTools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainPanel_OnDragEnter(object sender, DragEventArgs e)
        {
            e.Effects = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Link : DragDropEffects.None;
        }

        private void MainPanel_OnDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;
            var strs = (string[]) e.Data.GetData(DataFormats.FileDrop);
            if (strs == null || !strs.Any()) return;
            foreach (var str in strs)
            {
                var toolItem = new ToolItem
                {
                    FileName = str,
                    Name = Path.GetFileNameWithoutExtension(str)
                };
                var icon = FileHelper.GetShortcurIcoFromFilePath(str);
                if (icon != null)
                {
                    toolItem.Icon = IconHelper.ToByte(icon);
                }
                
            }
        }
    }
}
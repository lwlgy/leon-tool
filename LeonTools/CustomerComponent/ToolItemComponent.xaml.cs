using LeonTools.ViewModel;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Controls;

namespace LeonTools.CustomerComponent
{
    public partial class ToolItemComponent : UserControl
    {
        private MainView parent;
        public string Id { get; set; }
        public bool IsDragOver { get; set; }
        public ToolItemComponent()
        {
            InitializeComponent();
            Id = Guid.NewGuid().ToString();
        }

        public ToolItemComponent(ToolItemViewModel toolItem, MainView mainView) : this()
        {
            DataContext = toolItem;
            parent = mainView;
        }

        public ToolItemViewModel GetToolItemViewModel()
        {
            return (ToolItemViewModel)DataContext;
        }

        private void UserControl_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void miDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (parent != null)
            {
                parent.RemoveToolItem(this);
            }
        }

        private void UserControl_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        }

        private void UserControl_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void UserControl_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (DataContext is ToolItemViewModel tvm && !string.IsNullOrWhiteSpace(tvm.FileName) && File.Exists(tvm.FileName))
            {
                Consts.MainView.HideToTaskbar();
                Process.Start(tvm.FileName);
            }
        }
    }
}
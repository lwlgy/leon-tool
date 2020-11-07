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
        public ToolItemComponent()
        {
            InitializeComponent();
            this.Id = Guid.NewGuid().ToString();
        }

        public ToolItemComponent(ToolItemViewModel toolItem, MainView mainView) : this()
        {
            DataContext = toolItem;
            this.parent = mainView;
        }

        public ToolItemViewModel GetToolItemViewModel()
        {
            return (ToolItemViewModel)this.DataContext;
        }

        private void UserControl_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (DataContext is ToolItemViewModel tvm && !string.IsNullOrWhiteSpace(tvm.FileName) && File.Exists(tvm.FileName))
            {
                Process.Start(tvm.FileName);
            }
        }

        private void miDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.parent != null)
            {
                parent.RemoveToolItem(this);
            }
        }
    }
}
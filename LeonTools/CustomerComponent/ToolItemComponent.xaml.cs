using LeonTools.ViewModel;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;

namespace LeonTools.CustomerComponent
{
    public partial class ToolItemComponent : UserControl
    {
        private MainView parent;
        public string Id { get; set; }
        private bool isDragOver;

        public bool IsDragOver
        {
            get { return isDragOver; }
            set
            {
                isDragOver = value;
                if (value)
                {
                    this.itemBorder.BorderBrush = Brushes.Black;
                }
                else
                {
                    this.itemBorder.BorderBrush = Brushes.Transparent;
                }
            }
        }

        public ToolItemViewModel ToolItemViewModel { get; private set; }
        public string Text { get; set; }
        public ToolItemComponent()
        {
            InitializeComponent();

            Id = Guid.NewGuid().ToString();

        }

        public ToolItemComponent(ToolItemViewModel toolItem, MainView mainView) : this()
        {
            DataContext = toolItem;
            ToolItemViewModel = toolItem;
            Text = toolItem.Name;
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
            //if (DataContext is ToolItemViewModel tvm && !string.IsNullOrWhiteSpace(tvm.FileName) && File.Exists(tvm.FileName))
            //{
            //    Consts.MainView.HideToTaskbar();
            //    Process.Start(tvm.FileName);
            //}
        }
    }
}
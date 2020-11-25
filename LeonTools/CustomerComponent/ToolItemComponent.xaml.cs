using LeonTools.ViewModel;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using LeonTools.Common;

namespace LeonTools.CustomerComponent
{
    public partial class ToolItemComponent : UserControl
    {
        private readonly MainView parent;
        public string Id { get; set; }
        private bool _isDragOver;

        public bool IsDragOver
        {
            get => _isDragOver;
            set
            {
                _isDragOver = value;
                ItemBorder.BorderBrush = value ? Brushes.Black : Brushes.Transparent;
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
            return (ToolItemViewModel) DataContext;
        }

        private void UserControl_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        }

        private void miDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            parent?.RemoveToolItem(this);
        }

        private void miAdmin_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DataContext is ToolItemViewModel tvm && !string.IsNullOrWhiteSpace(tvm.FileName) &&
                File.Exists(tvm.FileName) && !Consts.MainView.IsDragging)
            {
                tvm.StartAsAdministrator();
                Consts.MainView.HideToTaskbar();
                Consts.MainView.StopDragToolItem();
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
            if (DataContext is ToolItemViewModel tvm && !string.IsNullOrWhiteSpace(tvm.FileName) &&
                File.Exists(tvm.FileName) && !Consts.MainView.IsDragging)
            {
                Process.Start(tvm.FileName);
                Consts.MainView.HideToTaskbar();
                Consts.MainView.StopDragToolItem();
            }
        }
    }
}
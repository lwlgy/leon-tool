using System.Windows;

namespace LeonTools.View
{
    /// <summary>
    /// SystemConfig.xaml 的交互逻辑
    /// </summary>
    public partial class SystemConfigView : Window
    {
        public SystemConfigView()
        {
            InitializeComponent();
        }

        private void BtnAddAutoStart_Click(object sender, RoutedEventArgs e)
        {
            Common.AutoStartHelper.StartAutomaticallyCreate(Consts.ApplicationName);
            MessageBox.Show("开机启动项添加成功！", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnRemoveAutoStart_Click(object sender, RoutedEventArgs e)
        {
            Common.AutoStartHelper.StartAutomaticallyDel(Consts.ApplicationName);
            MessageBox.Show("开机启动项移除成功！", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

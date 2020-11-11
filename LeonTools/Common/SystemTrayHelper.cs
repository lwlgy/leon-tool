using System;
using System.Windows;
using System.Windows.Forms;

namespace LeonTools.Common
{
    public static class SystemTrayHelper
    {
        public static void SetSystemTray(this Window window, Action show, Action hide)
        {
            NotifyIcon notifyIcon;
            notifyIcon = new NotifyIcon
            {
                BalloonTipText = "快速启动工具"
            };
            notifyIcon.ShowBalloonTip(2000);
            notifyIcon.Text = "快速启动工具";
            notifyIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath);
            notifyIcon.Visible = true;
            //打开菜单项
            MenuItem open = new MenuItem("打开");
            void showEvent(object o, EventArgs e)
            {
                if (show == null)
                {
                    window.Show();
                }
                else
                {
                    show();
                }
            }
            open.Click += new EventHandler(showEvent);
            //退出菜单项
            MenuItem exit = new MenuItem("关闭");
            exit.Click += (o, e) =>
            {
                notifyIcon.Visible = false;
                notifyIcon.Dispose();
                System.Windows.Application.Current.Shutdown(0);
            };
            //关联托盘控件
            MenuItem[] childen = new MenuItem[] { open, exit };
            notifyIcon.ContextMenu = new ContextMenu(childen);

            notifyIcon.MouseDoubleClick += new MouseEventHandler((o, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    showEvent(o, e);
                }
            });
        }
    }
}

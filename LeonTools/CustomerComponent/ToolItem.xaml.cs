using System.Windows.Controls;

namespace LeonTools.CustomerComponent
{
    public partial class ToolItem : UserControl
    {
        public ToolItem()
        {
            InitializeComponent();
            this.Width = Consts.LargeSizeWidth;
            this.Height = Consts.LargeSizeHeight;
        }
    }
}
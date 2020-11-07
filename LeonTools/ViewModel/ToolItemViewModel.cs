using System.ComponentModel;

namespace LeonTools.ViewModel
{
    public class ToolItemViewModel : INotifyPropertyChanged
    {
        public ToolItemViewModel(string name, string filePath, string fileName, byte[] icon)
        {
            Name = name;
            FilePath = filePath;
            FileName = fileName;
            Icon = icon;
        }

        public ToolItemViewModel()
        {
        }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        private string filePath;

        public string FilePath
        {
            get { return filePath; }
            set
            {
                filePath = value;
                RaisePropertyChanged("FilePath");
            }
        }

        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                RaisePropertyChanged("FileName");
            }
        }

        private byte[] icon;

        public byte[] Icon
        {
            get { return icon; }
            set
            {
                icon = value;
                RaisePropertyChanged("Icon");
            }
        }

        #region INotifyPropertyChanged属性
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region 方法
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
using LeonTools.Common;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace LeonTools.Converter
{
    [ValueConversion(typeof(byte[]), typeof(ImageSource))]
    public class ByteListToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            using (Icon icon = IconHelper.FromByte((byte[])value))
            {
                return icon.ToImageSource();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return IconHelper.ToByte((Icon)value);
        }
    }
}

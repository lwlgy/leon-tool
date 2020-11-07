using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LeonTools.Common
{
    public static class IconHelper
    {
        /// <summary>
        /// Byte转Icon
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static Icon FromByte(byte[] buffer)
        {
            using (MemoryStream ms = new MemoryStream(buffer))
            {
                using (Bitmap image = new Bitmap(ms))
                {
                    return Icon.FromHandle(image.GetHicon());

                }
            }
        }

        [DllImport("gdi32.dll", SetLastError = true)]
        private static extern bool DeleteObject(IntPtr hObject);

        public static ImageSource ToImageSource(this Icon icon)
        {
            Bitmap bitmap = icon.ToBitmap();
            IntPtr hBitmap = bitmap.GetHbitmap();

            ImageSource wpfBitmap = Imaging.CreateBitmapSourceFromHBitmap(
                hBitmap,
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());

            if (!DeleteObject(hBitmap))
            {
                throw new Win32Exception();
            }

            return wpfBitmap;
        }

        /// <summary>
        /// Icon转Byte
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        public static byte[] ToByte(Icon icon)
        {
            Encoder myEncoder = Encoder.Quality;
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 100);
            EncoderParameters encoders = new EncoderParameters(1);
            encoders.Param[0] = myEncoderParameter;
            ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/png");

            using (MemoryStream ms = new MemoryStream())
            {
                icon.ToBitmap().Save(ms, myImageCodecInfo, encoders);
                return ms.GetBuffer();
            }
        }

        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            int j;
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }

            return null;
        }
    }
}
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

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
            return Icon.FromHandle(new System.Drawing.Bitmap(new MemoryStream(buffer)).GetHicon());
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
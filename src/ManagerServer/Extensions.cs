using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Extensions
{
    public enum ImageFormat
    {
        bmp,
        jpg,
        jpeg,
        gif,
        tiff,
        tiff2,
        png,
        unknown
    }

    public static class ArrayExtensions
    {
        public static bool IsNullOrEmpty(this byte[] array)
        {
            return array == null | array.Length < 1;
        }
    }

    public static class BitmapExtensions
    {
        public static ImageFormat GetImageFormat(this byte[] bytes)
        {
            var bmp = Encoding.ASCII.GetBytes("BM"); // BMP 
            var gif = Encoding.ASCII.GetBytes("GIF"); // GIF 
            var png = new byte[] { 137, 80, 78, 71 }; // PNG 
            var tiff = new byte[] { 73, 73, 42 }; // TIFF 
            var tiff2 = new byte[] { 77, 77, 42 }; // TIFF 
            var jpg = new byte[] { 255, 216, 255, 224 }; // jpeg 
            var jpeg = new byte[] { 255, 216, 255, 225 }; // jpeg canon 

            if (bmp.SequenceEqual(bytes.Take(bmp.Length))) 
                return ImageFormat.bmp; 
            if (gif.SequenceEqual(bytes.Take(gif.Length))) 
                return ImageFormat.gif; 
            if (png.SequenceEqual(bytes.Take(png.Length))) 
                return ImageFormat.png; 
            if (tiff.SequenceEqual(bytes.Take(tiff.Length))) 
                return ImageFormat.tiff; 
            if (tiff2.SequenceEqual(bytes.Take(tiff2.Length))) 
                return ImageFormat.tiff2;
            if (jpg.SequenceEqual(bytes.Take(jpg.Length))) 
                return ImageFormat.jpg; 
            if (jpeg.SequenceEqual(bytes.Take(jpeg.Length))) 
                return ImageFormat.jpeg; 
            return ImageFormat.unknown; 
        }
            
        public static BitmapImage ToBitmapImage(this byte[] value)
        {
            var bytes = value;
            var image = new BitmapImage();
            if (ArrayExtensions.IsNullOrEmpty(value))
                return default;

            using (var ms = new MemoryStream(bytes))
            {
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
            }

            return image;
        }

        public static byte[] BitmapImageToByteArray(this BitmapImage @this)
        {
            Stream stream = @this.StreamSource;
            byte[] buffer = Array.Empty<byte>();
            if (stream != null && stream.Length > 0)
            {
                using (BinaryReader br = new BinaryReader(stream))
                    buffer = br.ReadBytes((int)stream.Length);
            }

            return buffer;
        }
    }
}

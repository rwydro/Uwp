using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ApiControlRobot
{
    static class BitMapHelpers
    {
        public static BitmapImage ToBitMapImage(this Bitmap bitmap)
        {
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            MemoryStream ns = new MemoryStream();
            bitmap.Save(ns, ImageFormat.Bmp);
            ns.Seek(0, SeekOrigin.Begin);
            bi.StreamSource = ns;
            bi.EndInit();
            return bi;
        }
    }
}

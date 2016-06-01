using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WindowsPhone_ImageResizer
{
    class utility
    {
        public static void imageResizer(string originalFileAddress, string scaledFileAddress, Size desiredSize)
        {
            using (Image src = Image.FromFile(originalFileAddress))
            using (Bitmap dst = new Bitmap(desiredSize.Width, desiredSize.Height))
            using (Graphics g = Graphics.FromImage(dst))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(src, 0, 0, dst.Width, dst.Height);
                dst.Save(scaledFileAddress, ImageFormat.Png);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Drawing.Imaging;

namespace RaceTrackMooi
{
    public static class LoadImage
    {        
        public static Dictionary<string, Bitmap> Images = new Dictionary<string, Bitmap>();
        public static Bitmap GetImages(string imageURL)
        {
            try
            {
                return Images[imageURL];
            }
            catch(Exception e)
            {
                Bitmap newImage = new Bitmap(imageURL);
                Images.Add(imageURL, newImage);
                return Images[imageURL];
            }
        }

        public static void ClearCache()
        {
            Images.Clear();
        }

        //Maakt een lege Bitmap aan
        public static Bitmap GetEmptyImage(int width, int height)
        {

            if (!Images.ContainsKey("empty"))
            {
                Bitmap bm = new Bitmap(width, height);
                Graphics graphic = Graphics.FromImage(bm);
                SolidBrush solidGray = new SolidBrush(System.Drawing.Color.FromArgb(128, 128, 128));
                graphic.FillRectangle(solidGray, 0, 0, width, height);

                Images.Add("empty", bm);
                return (Bitmap) Images["empty"].Clone();
            }
            else
            {
                return (Bitmap) Images["empty"].Clone();
            }
           
        }

        //zet een Bitmap om naar een BitmapSource
        public static BitmapSource CreateBitmapSourceFromGdiBitmap(Bitmap bitmap)
        {
            if (bitmap == null)
                throw new ArgumentNullException("bitmap");
            var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            var bitmapData = bitmap.LockBits(
            rect,
            ImageLockMode.ReadWrite,
            System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            try
            {
                var size = (rect.Width * rect.Height) * 4;
                return BitmapSource.Create(
                bitmap.Width,
                bitmap.Height,
                bitmap.HorizontalResolution,
                bitmap.VerticalResolution,
                PixelFormats.Bgra32,
                null,
                bitmapData.Scan0,
                size,
                bitmapData.Stride);
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);
            }
        }
    }
}

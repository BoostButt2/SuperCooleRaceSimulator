using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Drawing.Imaging;
using Model;

namespace RaceTrackMooi
{
    public static class VisualisationMooi
    {
        public static BitmapSource DrawTrack(Track track)
        {           
            return LoadImage.CreateBitmapSourceFromGdiBitmap(LoadImage.GetEmptyImage(100, 100));
        }
    }
}

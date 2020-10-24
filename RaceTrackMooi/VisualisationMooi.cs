using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Drawing.Imaging;
using Model;
using System.Linq;

namespace RaceTrackMooi
{
    public static class VisualisationMooi
    {
        public static BitmapSource DrawTrack(Track track)
        {
            //Section[] sections = track.Sections.ToArray();

            //foreach (Section section in sections)
            //{
            //    if (section.SectionType == SectionTypes.StartGrid)
            //    {
            //        LoadImage.GetImages(StartGrid);
            //    }

            //    if (section.SectionType == SectionTypes.Finish)
            //    {
            //        LoadImage.GetImages(Finish);
            //    }

            //    if (section.SectionType == SectionTypes.Straight)
            //    {
            //        LoadImage.GetImages(StraightHorizontal);
            //    }

            //    if (section.SectionType == SectionTypes.StraightVertical)
            //    {
            //        LoadImage.GetImages(StraightVertical);
            //    }

            //    if (section.SectionType == SectionTypes.RightCorner)
            //    {
            //        LoadImage.GetImages(RightCorner);
            //    }

            //    if (section.SectionType == SectionTypes.SuperRightCorner)
            //    {
            //        LoadImage.GetImages(SuperRightCorner);
            //    }

            //    if (section.SectionType == SectionTypes.LeftCorner)
            //    {
            //        LoadImage.GetImages(LeftCorner);
            //    }

            //    if (section.SectionType == SectionTypes.SuperLeftCorner)
            //    {
            //        LoadImage.GetImages(SuperLeftCorner);
            //    }
            //}

            return LoadImage.CreateBitmapSourceFromGdiBitmap(LoadImage.GetEmptyImage(100, 100));
        }

        #region
        public static string StartGrid = "/TrackVisual/StartGrid.png";
        public static string Finish = "/TrackVisual/Finish.png";
        public static string StraightHorizontal = "/TrackVisual/Straight_Horizontal.png";
        public static string StraightVertical = "/TrackVisual/Straight_Vertical.jpg";
        public static string RightCorner = "/TrackVisual/RightCorner.png";
        public static string SuperRightCorner = "/TrackVisual/SuperRightCOrner.jpg";
        public static string LeftCorner = "/TrackVisual/LeftCorner.jpg";
        public static string SuperLeftCorner = "/TrackVisual/SuperLeftCorner.jpg";
        public static string Lime = "/TrackVisual/Lime.png";
        public static string Pink = "/TrackVisual/Pink.png";
        public static string Orange = "/TrackVisual/Orange.png";
        public static string Blue = "/TrackVisual/blue.png";
        public static string Broken = "/TrackVisual/Broken.png";


        #endregion

    }
}

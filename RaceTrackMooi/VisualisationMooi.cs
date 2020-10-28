using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Drawing.Imaging;
using Model;
using System.Linq;
using System.Drawing.Drawing2D;

namespace RaceTrackMooi
{
    public static class VisualisationMooi
    {
        //Bewaart de x en y coördinaten
        private static int x;
        private static int y;


        public static BitmapSource DrawTrack(Track track)
        {
            Section[] sections = track.Sections.ToArray();

            foreach (Section section in sections)
            {
                if (section.SectionType == SectionTypes.StartGrid)
                {
                    LoadImage.GetImages(StartGrid);
                }

                if (section.SectionType == SectionTypes.Finish)
                {
                    LoadImage.GetImages(Finish);
                }

                if (section.SectionType == SectionTypes.Straight)
                {
                    LoadImage.GetImages(StraightHorizontal);
                }

                if (section.SectionType == SectionTypes.StraightVertical)
                {
                    LoadImage.GetImages(StraightVertical);
                }

                if (section.SectionType == SectionTypes.RightCorner)
                {
                    LoadImage.GetImages(RightCorner);
                }

                if (section.SectionType == SectionTypes.SuperRightCorner)
                {
                    LoadImage.GetImages(SuperRightCorner);
                }

                if (section.SectionType == SectionTypes.LeftCorner)
                {
                    LoadImage.GetImages(LeftCorner);
                }

                if (section.SectionType == SectionTypes.SuperLeftCorner)
                {
                    LoadImage.GetImages(SuperLeftCorner);
                }
            }
            //maakt de bitmap aan waar alle tracksections op getekend moeten worden
            Bitmap map = LoadImage.GetEmptyImage(1000, 1000);

            //Maakt de tracksection aan die getekend wordt op de map
            Bitmap start = LoadImage.Images[StartGrid];

            //Zorgt ervoor dat er getekend kan worden op de map
            Graphics g = Graphics.FromImage(map);
            g.CompositingMode = CompositingMode.SourceOver;

            //Zet de tracksection op de map met als parameters de tracksection, plek op x as, plek op y as
            g.DrawImage(start, 1, 1);

            return LoadImage.CreateBitmapSourceFromGdiBitmap(map);
        }

        #region
        public static string StartGrid = @"C:\Users\jesse\School\ICT M3.1\C#\SuperCooleRace\SuperCooleRace\RaceTrackMooi\TrackVisual\StartGrid.png";
        public static string Finish = @"C:\Users\jesse\School\ICT M3.1\C#\SuperCooleRace\SuperCooleRace\RaceTrackMooi\TrackVisual\Finish.png";
        public static string StraightHorizontal = @"C:\Users\jesse\School\ICT M3.1\C#\SuperCooleRace\SuperCooleRace\RaceTrackMooi\TrackVisual\Straight_Horizontal.png";
        public static string StraightVertical = @"C:\Users\jesse\School\ICT M3.1\C#\SuperCooleRace\SuperCooleRace\RaceTrackMooi\TrackVisual\Straight_Vertical.jpg";
        public static string RightCorner = @"C:\Users\jesse\School\ICT M3.1\C#\SuperCooleRace\SuperCooleRace\RaceTrackMooi\TrackVisual\RightCorner.png";
        public static string SuperRightCorner = @"C:\Users\jesse\School\ICT M3.1\C#\SuperCooleRace\SuperCooleRace\RaceTrackMooi\TrackVisual\SuperRightCOrner.jpg";
        public static string LeftCorner = @"C:\Users\jesse\School\ICT M3.1\C#\SuperCooleRace\SuperCooleRace\RaceTrackMooi\TrackVisual\LeftCorner.jpg";
        public static string SuperLeftCorner = @"C:\Users\jesse\School\ICT M3.1\C#\SuperCooleRace\SuperCooleRace\RaceTrackMooi\TrackVisual\SuperLeftCorner.jpg";
        public static string Lime = @"C:\Users\jesse\School\ICT M3.1\C#\SuperCooleRace\SuperCooleRace\RaceTrackMooi\TrackVisual\Lime.png";
        public static string Pink = @"C:\Users\jesse\School\ICT M3.1\C#\SuperCooleRace\SuperCooleRace\RaceTrackMooi\TrackVisual\Pink.png";
        public static string Orange = @"C:\Users\jesse\School\ICT M3.1\C#\SuperCooleRace\SuperCooleRace\RaceTrackMooi\TrackVisual\Orange.png";
        public static string Blue = @"C:\Users\jesse\School\ICT M3.1\C#\SuperCooleRace\SuperCooleRace\RaceTrackMooi\TrackVisual\blue.png";
        public static string Broken = @"C:\Users\jesse\School\ICT M3.1\C#\SuperCooleRace\SuperCooleRace\RaceTrackMooi\TrackVisual\Broken.png";


        #endregion

    }
}

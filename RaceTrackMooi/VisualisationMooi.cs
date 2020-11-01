using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Drawing.Imaging;
using Model;
using System.Linq;
using System.Drawing.Drawing2D;
using Controller;
using System.Drawing.Text;

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

            //Alle benodigde foto's worden in de cache gestopt
            #region
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
                LoadImage.GetImages(Blue);
                LoadImage.GetImages(Pink);
                LoadImage.GetImages(Orange);
                LoadImage.GetImages(Lime);
                LoadImage.GetImages(Broken);

            }
            #endregion

            //maakt de bitmap aan waar alle tracksections op getekend moeten worden
            Bitmap map = LoadImage.GetEmptyImage(1920, 1080);

            //Zorgt ervoor dat er getekend kan worden op de map
            Graphics g = Graphics.FromImage(map);
            g.CompositingMode = CompositingMode.SourceOver;

            Section[] hulpArray = track.Sections.ToArray();

            int right = 0;
            int superRight = 0;
            int left = 0;

            int linksX = 30;
            int linksY = 20;

            int rechtsX = 30;
            int rechtsY = 60;

            
            #region
            for (int i = 0; i < track.Sections.Count; i++)
            {
                if (Data.CurrentRace.KondigAan)
                {

                }
                Bitmap PlaatsLinks(Bitmap bm)
                {
                    //Linkerhelft
                    #region
                    //Plaatst de speler op links in de startgrid section
                    Bitmap newBM = new Bitmap(100, 100);
                    Graphics gr = Graphics.FromImage(newBM);
                    gr.CompositingMode = CompositingMode.SourceOver;
                    gr.DrawImage(bm, 0, 0);

                    if (Data.CurrentRace._positions[hulpArray[i]].Left.Equipment.IsBroken)
                    {
                        gr.DrawImage(LoadImage.Images[Broken], rechtsX, rechtsY);
                    }
                    else if (Data.CurrentRace._positions[hulpArray[i]].Left.TeamColor == TeamColors.Blue)
                    {
                        gr.DrawImage(LoadImage.Images[Blue], linksX, linksY);
                    }
                    else if (Data.CurrentRace._positions[hulpArray[i]].Left.TeamColor == TeamColors.Pink)
                    {
                        gr.DrawImage(LoadImage.Images[Pink], linksX, linksY);
                    }
                    else if (Data.CurrentRace._positions[hulpArray[i]].Left.TeamColor == TeamColors.Orange)
                    {
                        gr.DrawImage(LoadImage.Images[Orange], linksX, linksY);
                    }
                    else if (Data.CurrentRace._positions[hulpArray[i]].Left.TeamColor == TeamColors.Lime)
                    {
                        gr.DrawImage(LoadImage.Images[Lime], linksX, linksY);
                    }

                    return newBM;
                    #endregion
                }
                Bitmap PlaatsRechts(Bitmap bm)
                {
                    //Rechterhelft
                    #region
                    //Plaats de speler op rechts

                    Bitmap newBM = new Bitmap(100, 100);
                    Graphics gr = Graphics.FromImage(newBM);
                    gr.CompositingMode = CompositingMode.SourceOver;
                    gr.DrawImage(bm, 0, 0);

                    if (Data.CurrentRace._positions[hulpArray[i]].Right.Equipment.IsBroken)
                    {
                        gr.DrawImage(LoadImage.Images[Broken], rechtsX, rechtsY);
                    }
                    else if (Data.CurrentRace._positions[hulpArray[i]].Right.TeamColor == TeamColors.Blue)
                    {
                        gr.DrawImage(LoadImage.Images[Blue], rechtsX, rechtsY);
                    }
                    else if (Data.CurrentRace._positions[hulpArray[i]].Right.TeamColor == TeamColors.Pink)
                    {
                        gr.DrawImage(LoadImage.Images[Blue], rechtsX, rechtsY);
                    }
                    else if (Data.CurrentRace._positions[hulpArray[i]].Right.TeamColor == TeamColors.Orange)
                    {
                        gr.DrawImage(LoadImage.Images[Blue], rechtsX, rechtsY);
                    }
                    else if (Data.CurrentRace._positions[hulpArray[i]].Right.TeamColor == TeamColors.Lime)
                    {
                        gr.DrawImage(LoadImage.Images[Blue], rechtsX, rechtsY);
                    }

                    return newBM;
                    #endregion
                }
                Bitmap PlaatsBeide(Bitmap bm)
                {
                    //Rechterhelft
                    #region
                    //Plaats de speler op rechts

                    Bitmap newBM = new Bitmap(100, 100);
                    Graphics gr = Graphics.FromImage(newBM);
                    gr.CompositingMode = CompositingMode.SourceOver;
                    gr.DrawImage(bm, 0, 0);

                    if (Data.CurrentRace._positions[hulpArray[i]].Left.Equipment.IsBroken)
                    {
                        gr.DrawImage(LoadImage.Images[Broken], rechtsX, rechtsY);
                    }
                    else if (Data.CurrentRace._positions[hulpArray[i]].Left.TeamColor == TeamColors.Blue)
                    {
                        gr.DrawImage(LoadImage.Images[Blue], linksX, linksY);
                    }
                    else if (Data.CurrentRace._positions[hulpArray[i]].Left.TeamColor == TeamColors.Pink)
                    {
                        gr.DrawImage(LoadImage.Images[Pink], linksX, linksY);
                    }
                    else if (Data.CurrentRace._positions[hulpArray[i]].Left.TeamColor == TeamColors.Orange)
                    {
                        gr.DrawImage(LoadImage.Images[Orange], linksX, linksY);
                    }
                    else if (Data.CurrentRace._positions[hulpArray[i]].Left.TeamColor == TeamColors.Lime)
                    {
                        gr.DrawImage(LoadImage.Images[Lime], linksX, linksY);
                    }

                    if (Data.CurrentRace._positions[hulpArray[i]].Right.Equipment.IsBroken)
                    {
                        gr.DrawImage(LoadImage.Images[Broken], rechtsX, rechtsY);
                    }
                    else if (Data.CurrentRace._positions[hulpArray[i]].Right.TeamColor == TeamColors.Blue)
                    {
                        gr.DrawImage(LoadImage.Images[Blue], rechtsX, rechtsY);
                    }
                    else if (Data.CurrentRace._positions[hulpArray[i]].Right.TeamColor == TeamColors.Pink)
                    {
                        gr.DrawImage(LoadImage.Images[Pink], rechtsX, rechtsY);
                    }
                    else if (Data.CurrentRace._positions[hulpArray[i]].Right.TeamColor == TeamColors.Orange)
                    {
                        gr.DrawImage(LoadImage.Images[Orange], rechtsX, rechtsY);
                    }
                    else if (Data.CurrentRace._positions[hulpArray[i]].Right.TeamColor == TeamColors.Lime)
                    {
                        gr.DrawImage(LoadImage.Images[Lime], rechtsX, rechtsY);
                    }

                    return newBM;
                    #endregion
                }

                #region
                if (hulpArray[i].SectionType == SectionTypes.StartGrid)
                {

                    if (i == 0)
                    {
                        x = 600;
                        y = 0;
                    }
                    if(i != 0)
                    {
                        x += 100;
                    }


                    if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {
                        g.DrawImage(PlaatsBeide(LoadImage.Images[StartGrid]), x, y);

                    }

                    else if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right == null)
                    {

                        if (i == 0)
                        {
                            x = 600;
                            y = 0;
                        }
                        g.DrawImage(PlaatsLinks(LoadImage.Images[StartGrid]), x, y);

                    }
                    else if (Data.CurrentRace._positions[hulpArray[i]].Left == null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {

                        if (i == 0)
                        {
                            x = 600;
                            y = 0;
                        }

                        g.DrawImage(PlaatsRechts(LoadImage.Images[StartGrid]), x, y);
                    }
                    else
                    {
                        //Zet de tracksection op de map met als parameters de tracksection, plek op x as, plek op y as
                        g.DrawImage(LoadImage.Images[StartGrid], x, y);
                    }
                }

                if (hulpArray[i].SectionType == SectionTypes.Finish)
                {
                    x += 100;

                    if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {
                        g.DrawImage(PlaatsBeide(LoadImage.Images[Finish]), x, y);
                    }

                    else if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right == null)
                    {
                        g.DrawImage(PlaatsLinks(LoadImage.Images[Finish]), x, y);
                    }

                    else if (Data.CurrentRace._positions[hulpArray[i]].Left == null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {
                        g.DrawImage(PlaatsRechts(LoadImage.Images[Finish]), x, y);
                    }
                    else
                    {
                        g.DrawImage(LoadImage.Images[Finish], x, y);
                    }

                }

                if (hulpArray[i].SectionType == SectionTypes.RightCorner)
                {
                    right = 1;
                    superRight = 0;
                    if (left != 0)
                    {
                        y -= 100;
                        superRight = 0;
                        left = 0;
                    }
                    if(left == 0)
                    {
                        x += 100;
                    }


                    if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {
                        g.DrawImage(PlaatsBeide(LoadImage.Images[RightCorner]), x, y);
                    }

                    else if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right == null)
                    {
                        g.DrawImage(PlaatsLinks(LoadImage.Images[RightCorner]), x, y);
                    }

                    else if (Data.CurrentRace._positions[hulpArray[i]].Left == null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {
                        g.DrawImage(PlaatsRechts(LoadImage.Images[RightCorner]), x, y);
                    }
                    else
                    {
                        g.DrawImage(LoadImage.Images[RightCorner], x, y);
                    }

                }

                if (hulpArray[i].SectionType == SectionTypes.SuperRightCorner)
                {
                    superRight = 1;
                    left = 0;
                    if(right != 0)
                    {
                        y += 100;
                    }
                    if(right == 0)
                    {
                        x -= 100;
                    }

                    if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {
                        g.DrawImage(PlaatsBeide(LoadImage.Images[SuperRightCorner]), x, y);
                    }

                    else if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right == null)
                    {
                        g.DrawImage(PlaatsLinks(LoadImage.Images[SuperRightCorner]), x, y);
                    }

                    else if (Data.CurrentRace._positions[hulpArray[i]].Left == null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {
                        g.DrawImage(PlaatsRechts(LoadImage.Images[SuperRightCorner]), x, y);
                    }
                    else
                    {
                        g.DrawImage(LoadImage.Images[SuperRightCorner], x, y);
                    }

                }

                if (hulpArray[i].SectionType == SectionTypes.LeftCorner)
                {
                    right = 0;
                    left = 1;

                    if(superRight != 0)
                    {
                        x += 100;
                        superRight = 0;
                    }
                    if(superRight == 0)
                    {
                        y += 100;
                    }

                    if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {
                        g.DrawImage(PlaatsBeide(LoadImage.Images[LeftCorner]), x, y);
                    }

                    else if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right == null)
                    {
                        g.DrawImage(PlaatsLinks(LoadImage.Images[LeftCorner]), x, y);
                    }

                    else if (Data.CurrentRace._positions[hulpArray[i]].Left == null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {
                        g.DrawImage(PlaatsRechts(LoadImage.Images[LeftCorner]), x, y);
                    }
                    else
                    {
                        g.DrawImage(LoadImage.Images[LeftCorner], x, y);
                    }
  
                }
                if (hulpArray[i].SectionType == SectionTypes.SuperLeftCorner)
                {
                    superRight = 0;
                    if(right == 0)
                    {
                        y -= 100;
                    }

                    if (right != 0)
                    {
                        x -= 100;
                    }

                    if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {
                        g.DrawImage(PlaatsBeide(LoadImage.Images[SuperLeftCorner]), x, y);
                    }

                    else if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right == null)
                    {
                        g.DrawImage(PlaatsLinks(LoadImage.Images[SuperLeftCorner]), x, y);
                    }

                    else if (Data.CurrentRace._positions[hulpArray[i]].Left == null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {
                        g.DrawImage(PlaatsRechts(LoadImage.Images[SuperLeftCorner]), x, y);
                    }
                    else
                    {
                        g.DrawImage(LoadImage.Images[SuperLeftCorner], x, y);
                    }

                }

                if (hulpArray[i].SectionType == SectionTypes.Straight)
                {
                    if (left == 0)
                    {
                        x += 100;
                    }
                    if(left != 0)
                    {
                        x -= 100;
                    }


                    if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {
                        g.DrawImage(PlaatsBeide(LoadImage.Images[StraightHorizontal]), x, y);
                    }

                    else if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right == null)
                    {
                        g.DrawImage(PlaatsLinks(LoadImage.Images[StraightHorizontal]), x, y);
                    }

                    else if (Data.CurrentRace._positions[hulpArray[i]].Left == null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {
                        g.DrawImage(PlaatsRechts(LoadImage.Images[StraightHorizontal]), x, y);
                    }
                    else
                    {
                        g.DrawImage(LoadImage.Images[StraightHorizontal], x, y);
                    }

                }
                if (hulpArray[i].SectionType == SectionTypes.StraightVertical)
                {

                    if (superRight != 0)
                    {
                        y -= 100;
                    }
                    if (superRight == 0)
                    {
                        y += 100;
                    }


                    if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {
                        g.DrawImage(PlaatsBeide(LoadImage.Images[StraightVertical]), x, y);
                    }

                    else if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right == null)
                    {
                        g.DrawImage(PlaatsLinks(LoadImage.Images[StraightVertical]), x, y);
                    }

                    else if (Data.CurrentRace._positions[hulpArray[i]].Left == null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {
                        g.DrawImage(PlaatsRechts(LoadImage.Images[StraightVertical]), x, y);
                    }
                    else
                    {
                        g.DrawImage(LoadImage.Images[StraightVertical], x, y);
                    }

                }
            }
            #endregion
            #endregion

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

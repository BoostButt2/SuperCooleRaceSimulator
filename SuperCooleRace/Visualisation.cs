using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace SuperCooleRace
{
    public static class Visualisation
    {
        public static IParticipant noDriverLinks;
        public static IParticipant noDriverRechts;
        private static List<string[]> sectionArrays = new List<string[]>();
        private static List<string> hulpList = new List<string>();

        public static void Initialize()
        {

        }

        #region graphics
        private static string[] _finishHorizontal = { "----", " <# ", " ># ", "----" };
        private static string[] _startHorizontal = { "----", " <8 ", " >8 ", "----" };
        private static string[] _straightHorizontal = {"----", "  < ", "  > ", "----" };
        private static string[] _straightVertical = {"|  |", "|  |", "|<>|", "|  |" };
        private static string[] _rightCorner = {"----", "   |", " <>|", "-  |" };
        private static string[] _superRightCorner = {"|  -", "|   ", "|<> ", "----" };
        private static string[] _leftCorner = {"-  |", "   |", " <>|", "----" };
        private static string[] _superLeftCorner = {"----", "|   ", "|<> ", "|  -" };
      

        #endregion

        //Afhankelijk van de soort bocht wordt de cursor verplaatst
        public static void DrawTrack(Track track)
        {

            int right = 0;
            int superRight = 0;
            int left = 0;
            noDriverLinks = new Driver("<");
            noDriverRechts = new Driver(">");

            Section[] hulpArray = track.Sections.ToArray();
            #region
            for (int i = 0; i < track.Sections.Count; i++)
            {
                if (hulpArray[i].SectionType == SectionTypes.StartGrid)
                {
                    if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {
                        if (i == 0)
                        {
                            Console.SetCursorPosition(Console.CursorLeft + 24, Console.CursorTop);
                        }

                        if (i != 0)
                        {
                            Console.SetCursorPosition(Console.CursorLeft + 4, Console.CursorTop - 4);
                        }

                        foreach (string section in _startHorizontal)
                        {
                            Console.Write(PlaceDriver(section, Data.CurrentRace._positions[hulpArray[i]].Left, Data.CurrentRace._positions[hulpArray[i]].Right));
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }

                    else if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right == null)
                    {

                        if (i == 0)
                        {
                            Console.SetCursorPosition(Console.CursorLeft + 24, Console.CursorTop);
                        }

                        if (i != 0)
                        {
                            Console.SetCursorPosition(Console.CursorLeft + 4, Console.CursorTop - 4);
                        }

                        foreach (string section in _startHorizontal)
                        {
                            Console.Write(PlaceDriver(section, Data.CurrentRace._positions[hulpArray[i]].Left, noDriverRechts));
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }
                    else if (Data.CurrentRace._positions[hulpArray[i]].Left == null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {

                        if (i == 0)
                        {
                            Console.SetCursorPosition(Console.CursorLeft + 24, Console.CursorTop);
                        }

                        if (i != 0)
                        {
                            Console.SetCursorPosition(Console.CursorLeft + 4, Console.CursorTop - 4);
                        }

                        foreach (string section in _startHorizontal)
                        {
                            Console.Write(PlaceDriver(section, noDriverLinks, Data.CurrentRace._positions[hulpArray[i]].Right));
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }
                    else
                    {
                        if (i == 0)
                        {
                            Console.SetCursorPosition(Console.CursorLeft + 24, Console.CursorTop);
                        }

                        if (i != 0)
                        {
                            Console.SetCursorPosition(Console.CursorLeft + 4, Console.CursorTop - 4);
                        }

                        foreach (string section in _startHorizontal)
                        {
                            Console.Write(section);
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }
                }

                if (hulpArray[i].SectionType == SectionTypes.Finish)
                {
                    Console.SetCursorPosition(Console.CursorLeft + 4, Console.CursorTop - 4);
                    if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {
                        foreach (string section in _finishHorizontal)
                        {
                            Console.Write(PlaceDriver(section, Data.CurrentRace._positions[hulpArray[i]].Left, Data.CurrentRace._positions[hulpArray[i]].Right));
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }

                    else if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right == null)
                    {
                        foreach (string section in _finishHorizontal)
                        {
                            Console.Write(PlaceDriver(section, Data.CurrentRace._positions[hulpArray[i]].Left, noDriverRechts));
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }

                    else if (Data.CurrentRace._positions[hulpArray[i]].Left == null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {
                        foreach (string section in _finishHorizontal)
                        {
                            Console.Write(PlaceDriver(section, noDriverLinks, Data.CurrentRace._positions[hulpArray[i]].Right));
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }

                    else
                    {
                        foreach (string section in _finishHorizontal)
                        {
                            Console.Write(section);
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }
                }

                if (hulpArray[i].SectionType == SectionTypes.RightCorner)
                {
                    right = 1;
                    Console.SetCursorPosition(Console.CursorLeft + 4, Console.CursorTop - 4);

                    if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {
                        foreach (string section in _rightCorner)
                        {
                            Console.Write(PlaceDriver(section, Data.CurrentRace._positions[hulpArray[i]].Left, Data.CurrentRace._positions[hulpArray[i]].Right));
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }

                   else if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right == null)
                    {
                        foreach (string section in _rightCorner)
                        {
                            Console.Write(PlaceDriver(section, Data.CurrentRace._positions[hulpArray[i]].Left, noDriverRechts));
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }

                    else if (Data.CurrentRace._positions[hulpArray[i]].Left == null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {
                        foreach (string section in _rightCorner)
                        {
                            Console.Write(PlaceDriver(section, noDriverLinks, Data.CurrentRace._positions[hulpArray[i]].Right));
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }

                    else
                    {
                        foreach (string section in _rightCorner)
                        {
                            Console.Write(section);
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }
                }

                if (hulpArray[i].SectionType == SectionTypes.SuperRightCorner)
                {
                    superRight = 1;
                    left = 0;
                    if (right == 0)
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop - 4);
                    }

                    if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {
                        foreach (string section in _superRightCorner)
                        {
                            Console.Write(PlaceDriver(section, Data.CurrentRace._positions[hulpArray[i]].Left, Data.CurrentRace._positions[hulpArray[i]].Right));
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }

                    else if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right == null)
                    {
                        foreach (string section in _superRightCorner)
                        {
                            Console.Write(PlaceDriver(section, Data.CurrentRace._positions[hulpArray[i]].Left, noDriverRechts));
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }

                    else if (Data.CurrentRace._positions[hulpArray[i]].Left == null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {
                        foreach (string section in _superRightCorner)
                        {
                            Console.Write(PlaceDriver(section, noDriverLinks, Data.CurrentRace._positions[hulpArray[i]].Right));
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }

                    else
                    {
                        foreach (string section in _superRightCorner)
                        {
                            Console.Write(section);
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }
                }

                if (hulpArray[i].SectionType == SectionTypes.LeftCorner)
                {
                    right = 0;
                    left = 1;

                    if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {
                        foreach (string section in _leftCorner)
                        {
                            Console.Write(PlaceDriver(section, Data.CurrentRace._positions[hulpArray[i]].Left, Data.CurrentRace._positions[hulpArray[i]].Right));
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }

                    else if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right == null)
                    {
                        foreach (string section in _leftCorner)
                        {
                            Console.Write(PlaceDriver(section, Data.CurrentRace._positions[hulpArray[i]].Left, noDriverRechts));
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }

                    else if (Data.CurrentRace._positions[hulpArray[i]].Left == null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {
                        foreach (string section in _leftCorner)
                        {
                            Console.Write(PlaceDriver(section, noDriverLinks, Data.CurrentRace._positions[hulpArray[i]].Right));
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }
                    else
                    {
                        foreach (string section in _leftCorner)
                        {
                            Console.Write(section);
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }
                }
                if (hulpArray[i].SectionType == SectionTypes.SuperLeftCorner)
                {
                    superRight = 0;
                    try
                    {
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 8);
                    }
                    catch(Exception e)
                    {

                    }

                    if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {
                        foreach (string section in _superLeftCorner)
                        {
                            Console.Write(PlaceDriver(section, Data.CurrentRace._positions[hulpArray[i]].Left, Data.CurrentRace._positions[hulpArray[i]].Right));
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }

                    else if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right == null)
                    {
                        foreach (string section in _superLeftCorner)
                        {
                            Console.Write(PlaceDriver(section, Data.CurrentRace._positions[hulpArray[i]].Left, noDriverRechts));
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }

                    else if (Data.CurrentRace._positions[hulpArray[i]].Left == null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {
                        foreach (string section in _superLeftCorner)
                        {
                            Console.Write(PlaceDriver(section, noDriverLinks, Data.CurrentRace._positions[hulpArray[i]].Right));
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }

                    else
                    {
                        foreach (string section in _superLeftCorner)
                        {
                            Console.Write(section);
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }
                }

                if (hulpArray[i].SectionType == SectionTypes.Straight)
                {
                    if (left == 1)
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop - 4);
                    }
                    else
                    {

                        Console.SetCursorPosition(Console.CursorLeft + 4, Console.CursorTop - 4);
                    }

                    if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {
                        foreach (string section in _straightHorizontal)
                        {
                            Console.Write(PlaceDriver(section, Data.CurrentRace._positions[hulpArray[i]].Left, Data.CurrentRace._positions[hulpArray[i]].Right));
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }

                    else if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right == null)
                    {
                        foreach (string section in _straightHorizontal)
                        {
                            Console.Write(PlaceDriver(section, Data.CurrentRace._positions[hulpArray[i]].Left, noDriverRechts));
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }

                    else if (Data.CurrentRace._positions[hulpArray[i]].Left == null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {
                        foreach (string section in _straightHorizontal)
                        {
                            Console.Write(PlaceDriver(section, noDriverLinks, Data.CurrentRace._positions[hulpArray[i]].Right));
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }

                    else
                    {
                        foreach (string section in _straightHorizontal)
                        {
                            Console.Write(section);
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }
                }
                if (hulpArray[i].SectionType == SectionTypes.StraightVertical)
                {
                    
                    if(superRight == 1)
                    {
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 8);
                    }

                    if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {
                        foreach (string section in _straightVertical)
                        {
                            Console.Write(PlaceDriver(section, Data.CurrentRace._positions[hulpArray[i]].Left, Data.CurrentRace._positions[hulpArray[i]].Right));
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }

                    else if (Data.CurrentRace._positions[hulpArray[i]].Left != null && Data.CurrentRace._positions[hulpArray[i]].Right == null)
                    {
                        foreach (string section in _straightVertical)
                        {
                            Console.Write(PlaceDriver(section, Data.CurrentRace._positions[hulpArray[i]].Left, noDriverRechts));
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }

                    else if (Data.CurrentRace._positions[hulpArray[i]].Left == null && Data.CurrentRace._positions[hulpArray[i]].Right != null)
                    {
                        foreach (string section in _straightVertical)
                        {
                            Console.Write(PlaceDriver(section, noDriverLinks, Data.CurrentRace._positions[hulpArray[i]].Right));
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }
                    else
                    {

                        foreach (string section in _straightVertical)
                        {
                            Console.Write(section);
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }
                }
            }
            #endregion
            if (Data.CurrentRace.KondigAan)
            {
                Console.WriteLine($"De eerste plek is behaald door {Data.DriversInOrder.GetBestDriver()}");
            }
        }

        public static string PlaceDriver(string s, IParticipant leftDriver, IParticipant rightDriver)
        {
            string left = leftDriver.Name.Substring(0, 1);
            string right = rightDriver.Name.Substring(0, 1);

            if (leftDriver.Equipment.IsBroken)
            {
                left = "^";
            }

            if (rightDriver.Equipment.IsBroken)
            {
                right = "^";
            }

            s = s.Replace("<", left);
            s = s.Replace(">", right);
            return s;
        }

        public static void StartRace()
        {
            DriversChangedEventArgs driversChangedEventArgs = new DriversChangedEventArgs();
            driversChangedEventArgs.track = Data.CurrentRace.Track;

            DrawTrack(Data.CurrentRace.Track);

            Data.CurrentRace.Driverschanged += OnDriversChanged;
            Data.CurrentRace.NewRaceEvent += StartRace;
        }


        public static void OnDriversChanged(object sender, EventArgs e)
        {
            Console.Clear();
            Console.WriteLine(Data.CurrentRace.Track.Name);
            DrawTrack(Data.CurrentRace.Track);
        }

        #region
        //public static void DrawTrackOG(Track track)
        //{

        //    foreach(Section sect in track.Sections)
        //    {

        //        if(sect.SectionType == SectionTypes.Finish)
        //        {

        //            foreach (string finish in _finishHorizontal)
        //            {
        //                string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
        //                Console.WriteLine(sectionMetDriver);
        //            }
        //        }
        //        if (sect.SectionType == SectionTypes.FinishVertical)
        //        {
        //            foreach (string finish in _finishVertical)
        //            {
        //                string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
        //                Console.WriteLine(sectionMetDriver);
        //            }
        //        }
        //        if (sect.SectionType == SectionTypes.StartGrid)
        //        {
        //            foreach (string finish in _startHorizontal)
        //            {
        //                string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
        //                Console.WriteLine(sectionMetDriver);
        //            }
        //        }
        //        if (sect.SectionType == SectionTypes.StartVertical)
        //        {
        //            foreach (string finish in _startVertical)
        //            {
        //                string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
        //                Console.WriteLine(sectionMetDriver);
        //            }
        //        }
        //        if (sect.SectionType == SectionTypes.Straight)
        //        {
        //            foreach (string finish in _straightHorizontal)
        //            {
        //                string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
        //                Console.WriteLine(sectionMetDriver);
        //            }
        //        }
        //        if (sect.SectionType == SectionTypes.StraightVertical)
        //        {
        //            foreach (string finish in _straightVertical)
        //            {
        //                string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
        //                Console.WriteLine(sectionMetDriver);
        //            }
        //        }
        //        if (sect.SectionType == SectionTypes.RightCorner)
        //        {
        //            foreach (string finish in _rightCorner)
        //            {
        //                string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
        //                Console.WriteLine(sectionMetDriver);
        //            }
        //        }
        //        if (sect.SectionType == SectionTypes.SuperRightCorner)
        //        {
        //            foreach (string finish in _superRightCorner)
        //            {
        //                string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
        //                Console.WriteLine(sectionMetDriver);
        //            }
        //        }
        //        if (sect.SectionType == SectionTypes.LeftCorner)
        //        {
        //            foreach (string finish in _leftCorner)
        //            {
        //                string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
        //                Console.WriteLine(sectionMetDriver);
        //            }
        //        }
        //        if (sect.SectionType == SectionTypes.SuperLeftCorner)
        //        {
        //            foreach (string finish in _superLeftCorner)
        //            {
        //                string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
        //                Console.WriteLine(sectionMetDriver);
        //            }
        //        }
        //    }
        //}
        #endregion


    }
}

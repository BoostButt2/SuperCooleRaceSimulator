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
        public static IParticipant driverLeft;
        public static IParticipant driverRightt;
        private static List<string[]> sectionArrays = new List<string[]>();
        private static List<string> hulpList = new List<string>();

        public static void Initialize()
        {

        }

        #region graphics
        private static string[] _finishHorizontal = { "----", " <# ", " ># ", "----" };
        private static string[] _finishVertical = { "|  |", "|##|", "|<>|", "|  |" };
        private static string[] _startHorizontal = { "----", " <8 ", " >8 ", "----" };
        private static string[] _startVertical = { "|  |", "|88|", "|<>|", "|  |" };
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

            Section[] hulpArray = track.Sections.ToArray();

            Section[] p = track.Sections.ToArray();
            for (int i = 0; i < track.Sections.Count; i++)
            {
                if (hulpArray[i].SectionType == SectionTypes.StartGrid)
                {
                    if (i == 0)
                    {
                        Console.SetCursorPosition(Console.CursorLeft + 24, Console.CursorTop);
                    }
                    else
                    {
                        Console.SetCursorPosition(Console.CursorLeft + 4, Console.CursorTop - 4);
                    }
                    if (i == Data.CurrentRace.currentSection)
                    {
                        foreach (string section in _startHorizontal)
                        {
                            Console.Write(PlaceDriver(section, driverLeft, driverRightt));
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }
                    else
                    {
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
                    if (i == Data.CurrentRace.currentSection)
                    {
                        foreach (string section in _finishHorizontal)
                        {
                            Console.Write(PlaceDriver(section, driverLeft, driverRightt));
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

                    if (i == Data.CurrentRace.currentSection)
                    {
                        foreach (string section in _rightCorner)
                        {
                            Console.Write(PlaceDriver(section, driverLeft, driverRightt));
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
                    Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop - 4);

                    if (i == Data.CurrentRace.currentSection)
                    {
                        foreach (string section in _superRightCorner)
                        {
                            Console.Write(PlaceDriver(section, driverLeft, driverRightt));
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

                    if (i == Data.CurrentRace.currentSection)
                    {
                        foreach (string section in _leftCorner)
                        {
                            Console.Write(PlaceDriver(section, driverLeft, driverRightt));
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

                    if (i == Data.CurrentRace.currentSection)
                    {
                        foreach (string section in _superLeftCorner)
                        {
                            Console.Write(PlaceDriver(section, driverLeft, driverRightt));
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

                    if (i == Data.CurrentRace.currentSection)
                    {
                        foreach (string section in _straightHorizontal)
                        {
                            Console.Write(PlaceDriver(section, driverLeft, driverRightt));
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

                    if (i == Data.CurrentRace.currentSection)
                    {
                        foreach (string section in _straightVertical)
                        {
                            Console.Write(PlaceDriver(section, driverLeft, driverRightt));
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
        }

        public static string PlaceDriver(string s, IParticipant leftDriver, IParticipant rightDriver)
        {
            string left = leftDriver.Name.Substring(0, 1);
            string right = rightDriver.Name.Substring(0, 1);
            s = s.Replace("<", left);
            s = s.Replace(">", right);
            return s;
        }

        public static void StartRace()
        {
            DrawTrack(Data.CurrentRace.Track);
            DriversChangedEventArgs driversChangedEventArgs = new DriversChangedEventArgs();
            driversChangedEventArgs.track = Data.CurrentRace.Track;

            Data.CurrentRace.Driverschanged += OnDriversChanged;
        }
        public static void OnDriversChanged(object sender, DriversChangedEventArgs e)
        {
            Console.Clear();
            Console.WriteLine(e.track.Name);
            DrawTrack(e.track);
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

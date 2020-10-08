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
        private static string[] _emptyField = { "    ", "    ", "    ", "    " };
      

        #endregion

        //Zoek naar cursor positie veranderen / print positie veranderen
        public static void DrawTrack(Track track)
        {
            int right = 0;
            int superRight = 0;
            int left = 0;
            Section[] p = track.Sections.ToArray();
            foreach(Section sect in track.Sections)
            {
                if (sect.SectionType == SectionTypes.StartGrid)
                {
                    Console.SetCursorPosition(Console.CursorLeft + 24, Console.CursorTop);
                    foreach (string section in _startHorizontal)
                    {
                        Console.Write(section);
                        Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                    }
                }

                if (sect.SectionType == SectionTypes.Finish)
                {
                    foreach (string section in _finishHorizontal)
                    {
                        Console.Write(section);
                        Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                    }
                }

                if (sect.SectionType == SectionTypes.RightCorner)
                {
                    right = 1;
                    Console.SetCursorPosition(Console.CursorLeft + 4, Console.CursorTop - 4);
                    foreach(string section in _rightCorner)
                    {
                        Console.Write(section);
                        Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                    }
                }

                if (sect.SectionType == SectionTypes.SuperRightCorner)
                {
                    superRight = 1;
                    left = 0;
                    Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop - 4);
                    foreach (string section in _rightCorner)
                    {
                        Console.Write(section);
                        Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                    }
                }

                if (sect.SectionType == SectionTypes.LeftCorner)
                {
                    right = 0;
                    left = 1;
                    foreach (string section in _rightCorner)
                    {
                        Console.Write(section);
                        Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                    }
                }
                if (sect.SectionType == SectionTypes.SuperLeftCorner)
                {
                    superRight = 0;
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 8);
                    foreach (string section in _rightCorner)
                    {
                        Console.Write(section);
                        Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                    }
                }

                if (sect.SectionType == SectionTypes.Straight)
                {
                    if (left == 1)
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop - 4);
                    }
                    else
                    {

                        Console.SetCursorPosition(Console.CursorLeft + 4, Console.CursorTop - 4);
                    }
                    foreach (string section in _rightCorner)
                    {
                        Console.Write(section);
                        Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                    }
                }
                if (sect.SectionType == SectionTypes.StraightVertical)
                {
                    if (right == 1)
                    {
                        foreach (string section in _straightVertical)
                        {
                            Console.Write(section);
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }
                    if(superRight == 1)
                    {
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 8);
                        foreach (string section in _straightVertical)
                        {
                            Console.Write(section);
                            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop + 1);
                        }
                    }
                }


            }

            //foreach (Section sect in track.Sections)
            //{
            //    //print alle tracks naast elkaar, regel voor regel. Alle strings worden van links naar rechts geprint.
            //    if (sect.SectionType == SectionTypes.NextLine)
            //    {
            //        for (int i = 0; i < 4; i++)
            //        {
            //            foreach (string[] sectionArray in sectionArrays)
            //            {
            //                Console.Write(sectionArray[i]);
            //            }
            //            Console.Write("\n");
            //        }
            //        //Als alle sections van de eerste rij zijn geprint, wordt de array leeg gemaakt om ruimte te maken voor een nieuwe rij
            //        sectionArrays.Clear();
            //    }

            //    if (sect.SectionType == SectionTypes.EmptyField)
            //    {
            //        foreach (string finish in _emptyField)
            //        {
            //            string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
            //            hulpList.Add(sectionMetDriver);
            //        }
            //        string[] hulpArray = hulpList.ToArray();
            //        sectionArrays.Add(hulpArray);
            //        hulpList.Clear();
            //    }

            //    if (sect.SectionType == SectionTypes.Finish)
            //    {
            //        if (sect.SectionType == Data.CurrentRace.currentSection.SectionType)
            //        {
            //            foreach (string finish in _finishHorizontal)
            //            {
            //                string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
            //                hulpList.Add(sectionMetDriver);
            //            }
            //            string[] hulpArray = hulpList.ToArray();
            //            sectionArrays.Add(hulpArray);
            //            hulpList.Clear();
            //        }
            //        else
            //        {
            //            sectionArrays.Add(_finishHorizontal);
            //        }
            //    }

            //    if (sect.SectionType == SectionTypes.FinishVertical)
            //    {
            //        if (sect.SectionType == Data.CurrentRace.currentSection.SectionType)
            //        {
            //            foreach (string finish in _finishVertical)
            //            {
            //                string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
            //                hulpList.Add(sectionMetDriver);
            //            }
            //            string[] hulpArray = hulpList.ToArray();
            //            sectionArrays.Add(hulpArray);
            //            hulpList.Clear();
            //        }
            //        else
            //        {
            //            sectionArrays.Add(_finishVertical);
            //        }
            //    }

            //    if (sect.SectionType == SectionTypes.StartGrid)
            //    {
            //        if (sect.SectionType == Data.CurrentRace.currentSection.SectionType)
            //        {
            //            foreach (string finish in _startHorizontal)
            //            {
            //                string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
            //                hulpList.Add(sectionMetDriver);
            //            }
            //            string[] hulpArray = hulpList.ToArray();
            //            sectionArrays.Add(hulpArray);
            //            hulpList.Clear();
            //        }
            //        else
            //        {
            //            sectionArrays.Add(_startHorizontal);
            //        }
            //    }

            //    if (sect.SectionType == SectionTypes.StartVertical)
            //    {
            //        if (sect.SectionType == Data.CurrentRace.currentSection.SectionType)
            //        {
            //            foreach (string finish in _startVertical)
            //            {
            //                string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
            //                hulpList.Add(sectionMetDriver);
            //            }
            //            string[] hulpArray = hulpList.ToArray();
            //            sectionArrays.Add(hulpArray);
            //            hulpList.Clear();
            //        }
            //        else
            //        {
            //            sectionArrays.Add(_startVertical);
            //        }
            //    }

            //    if (sect.SectionType == SectionTypes.Straight)
            //    {
            //        if (sect.SectionType == Data.CurrentRace.currentSection.SectionType)
            //        {
            //            foreach (string finish in _straightHorizontal)
            //            {
            //                string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
            //                hulpList.Add(sectionMetDriver);
            //            }
            //            string[] hulpArray = hulpList.ToArray();
            //            sectionArrays.Add(hulpArray);
            //            hulpList.Clear();
            //        }
            //        else
            //        {
            //            sectionArrays.Add(_straightHorizontal);
            //        }
            //    }

            //    if (sect.SectionType == SectionTypes.StraightVertical)
            //    {
            //        if (sect.SectionType == Data.CurrentRace.currentSection.SectionType)
            //        {
            //            foreach (string finish in _straightVertical)
            //            {
            //                string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
            //                hulpList.Add(sectionMetDriver);
            //            }
            //            string[] hulpArray = hulpList.ToArray();
            //            sectionArrays.Add(hulpArray);
            //            hulpList.Clear();
            //        }
            //        else
            //        {
            //            sectionArrays.Add(_straightVertical);
            //        }
            //    }

            //    if (sect.SectionType == SectionTypes.RightCorner)
            //    {
            //        if (sect.SectionType == Data.CurrentRace.currentSection.SectionType)
            //        {
            //            foreach (string finish in _rightCorner)
            //            {
            //                string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
            //                hulpList.Add(sectionMetDriver);
            //            }
            //            string[] hulpArray = hulpList.ToArray();
            //            sectionArrays.Add(hulpArray);
            //            hulpList.Clear();
            //        }
            //        else
            //        {
            //            sectionArrays.Add(_rightCorner);
            //        }
            //    }

            //    if (sect.SectionType == SectionTypes.SuperRightCorner)
            //    {
            //        if (sect.SectionType == Data.CurrentRace.currentSection.SectionType)
            //        {
            //            foreach (string finish in _superRightCorner)
            //            {
            //                string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
            //                hulpList.Add(sectionMetDriver);
            //            }
            //            string[] hulpArray = hulpList.ToArray();
            //            sectionArrays.Add(hulpArray);
            //            hulpList.Clear();
            //        }
            //        else
            //        {
            //            sectionArrays.Add(_superRightCorner);
            //        }
            //    }

            //    if (sect.SectionType == SectionTypes.LeftCorner)
            //    {
            //        if (sect.SectionType == Data.CurrentRace.currentSection.SectionType)
            //        {
            //            foreach (string finish in _leftCorner)
            //            {
            //                string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
            //                hulpList.Add(sectionMetDriver);
            //            }
            //            string[] hulpArray = hulpList.ToArray();
            //            sectionArrays.Add(hulpArray);
            //            hulpList.Clear();
            //        }
            //        else
            //        {
            //            sectionArrays.Add(_leftCorner);
            //        }
            //    }

            //    if (sect.SectionType == SectionTypes.SuperLeftCorner)
            //    {
            //        if (sect.SectionType == Data.CurrentRace.currentSection.SectionType)
            //        {
            //            foreach (string finish in _superLeftCorner)
            //            {
            //                string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
            //                hulpList.Add(sectionMetDriver);
            //            }
            //            string[] hulpArray = hulpList.ToArray();
            //            sectionArrays.Add(hulpArray);
            //            hulpList.Clear();
            //        }
            //        else
            //        {
            //            sectionArrays.Add(_superLeftCorner);
            //        }
            //    }
            //}
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
            DriversChangedEventArgs driversChangedEventArgs = new DriversChangedEventArgs();
            driversChangedEventArgs.track = Data.CurrentRace.Track;
            OnDriversChanged(Data.CurrentRace, driversChangedEventArgs);
        }
        public static void OnDriversChanged(object sender, DriversChangedEventArgs e)
        {
            Console.Clear();
            DrawTrack(e.track);
            Data.CurrentRace.Driverschanged += OnDriversChanged;
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

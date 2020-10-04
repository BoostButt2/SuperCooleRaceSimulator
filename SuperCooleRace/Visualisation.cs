using Controller;
using Model;
using System;
using System.Collections.Generic;
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

        public static void DrawTrack(Track track)
        {
            foreach (Section sect in track.Sections)
            {
                //print alle tracks naast elkaar, regel voor regel. Alle strings worden van links naar rechts geprint.
                if (sect.SectionType == SectionTypes.NextLine)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        foreach (string[] sectionArray in sectionArrays)
                        {
                            Console.Write(sectionArray[i]);
                        }
                        Console.Write("\n");
                    }

                    sectionArrays.Clear();
                }

                if (sect.SectionType == SectionTypes.Finish)
                {
                    foreach (string finish in _finishHorizontal)
                    {
                        string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
                        hulpList.Add(sectionMetDriver);
                    }
                    string[] hulpArray = hulpList.ToArray();
                    sectionArrays.Add(hulpArray);
                    hulpList.Clear();
                }

                if (sect.SectionType == SectionTypes.FinishVertical)
                {
                    foreach (string finish in _finishVertical)
                    {
                        string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
                        hulpList.Add(sectionMetDriver);
                    }
                    string[] hulpArray = hulpList.ToArray();
                    sectionArrays.Add(hulpArray);
                    hulpList.Clear();
                }

                if (sect.SectionType == SectionTypes.StartGrid)
                {
                    foreach (string finish in _startHorizontal)
                    {
                        string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
                        hulpList.Add(sectionMetDriver);
                    }
                    string[] hulpArray = hulpList.ToArray();
                    sectionArrays.Add(hulpArray);
                    hulpList.Clear();
                }

                if (sect.SectionType == SectionTypes.StartVertical)
                {
                    foreach (string finish in _startVertical)
                    {
                        string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
                        hulpList.Add(sectionMetDriver);
                    }
                    string[] hulpArray = hulpList.ToArray();
                    sectionArrays.Add(hulpArray);
                    hulpList.Clear();
                }

                if (sect.SectionType == SectionTypes.Straight)
                {
                    foreach (string finish in _straightHorizontal)
                    {
                        string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
                        hulpList.Add(sectionMetDriver);
                    }
                    string[] hulpArray = hulpList.ToArray();
                    sectionArrays.Add(hulpArray);
                    hulpList.Clear();
                }
                if (sect.SectionType == SectionTypes.StraightVertical)
                {
                    foreach (string finish in _straightVertical)
                    {
                        string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
                        hulpList.Add(sectionMetDriver);
                    }
                    string[] hulpArray = hulpList.ToArray();
                    sectionArrays.Add(hulpArray);
                    hulpList.Clear();
                }

                if (sect.SectionType == SectionTypes.RightCorner)
                {
                    foreach (string finish in _rightCorner)
                    {
                        string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
                        hulpList.Add(sectionMetDriver);
                    }
                    string[] hulpArray = hulpList.ToArray();
                    sectionArrays.Add(hulpArray);
                    hulpList.Clear();
                }

                if (sect.SectionType == SectionTypes.SuperRightCorner)
                {
                    foreach (string finish in _superRightCorner)
                    {
                        string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
                        hulpList.Add(sectionMetDriver);
                    }
                    string[] hulpArray = hulpList.ToArray();
                    sectionArrays.Add(hulpArray);
                    hulpList.Clear();
                }

                if (sect.SectionType == SectionTypes.LeftCorner)
                {
                    foreach (string finish in _leftCorner)
                    {
                        string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
                        hulpList.Add(sectionMetDriver);
                    }
                    string[] hulpArray = hulpList.ToArray();
                    sectionArrays.Add(hulpArray);
                    hulpList.Clear();
                }

                if (sect.SectionType == SectionTypes.SuperLeftCorner)
                {
                    foreach (string finish in _superLeftCorner)
                    {
                        string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
                        hulpList.Add(sectionMetDriver);
                    }
                    string[] hulpArray = hulpList.ToArray();
                    sectionArrays.Add(hulpArray);
                    hulpList.Clear();
                }
            }
        }

        public static string PlaceDriver(string s, IParticipant leftDriver, IParticipant rightDriver)
        {
            s = s.Replace("<", "L");
            s = s.Replace(">", "R");
            return s;
        }

        public static void OnDriversChanged(object sender, DriversChangedEventArgs e)
        {
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

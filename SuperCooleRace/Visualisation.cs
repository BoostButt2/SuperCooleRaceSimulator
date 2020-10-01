using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCooleRace
{
    public static class Visualisation
    {
        public static IParticipant driverLeft;
        public static IParticipant driverRightt;

        public static void Initialize()
        {

        }

        #region graphics
        private static string[] _finishHorizontal = { "----", " <# ", " ># ", "----" };
        private static string[] _finishVertical = { "|  |", "|##|", "|<>|", "|  |" };
        private static string[] _startHorizontal = { "----", " <8 ", " >8 ", "----" };
        private static string[] _startVertical = { "|  |", "|88|", "|<>|", "|  |" };
        private static string[] _straightHorizontal = {"----", "    ", "    ", "----" };
        private static string[] _straightVertical = {"|  |", "|  |", "|<>|", "|  |" };
        private static string[] _rightCorner = {"----", "   |", " <>|", "-  |" };
        private static string[] _superRightCorner = {"|  -", "|   ", "|<> ", "----" };
        private static string[] _leftCorner = {"-  |", "   |", " <>|", "----" };
        private static string[] _superLeftCorner = {"----", "|   ", "|<> ", "|  -" };


        #endregion

        public static void DrawTrack(Track track)
        {
            foreach(Section sect in track.Sections)
            {
                if(sect.SectionType == SectionTypes.Finish)
                {
                    foreach (string finish in _finishHorizontal)
                    {
                        string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
                        Console.WriteLine(sectionMetDriver);
                    }
                }
                if (sect.SectionType == SectionTypes.FinishVertical)
                {
                    foreach (string finish in _finishVertical)
                    {
                        string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
                        Console.WriteLine(sectionMetDriver);
                    }
                }
                if (sect.SectionType == SectionTypes.StartGrid)
                {
                    foreach (string finish in _startHorizontal)
                    {
                        string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
                        Console.WriteLine(sectionMetDriver);
                    }
                }
                if (sect.SectionType == SectionTypes.StartVertical)
                {
                    foreach (string finish in _startVertical)
                    {
                        string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
                        Console.WriteLine(sectionMetDriver);
                    }
                }
                if (sect.SectionType == SectionTypes.Straight)
                {
                    foreach (string finish in _straightHorizontal)
                    {
                        string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
                        Console.WriteLine(sectionMetDriver);
                    }
                }
                if (sect.SectionType == SectionTypes.StraightVertical)
                {
                    foreach (string finish in _straightVertical)
                    {
                        string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
                        Console.WriteLine(sectionMetDriver);
                    }
                }
                if (sect.SectionType == SectionTypes.RightCorner)
                {
                    foreach (string finish in _rightCorner)
                    {
                        string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
                        Console.WriteLine(sectionMetDriver);
                    }
                }
                if (sect.SectionType == SectionTypes.SuperRightCorner)
                {
                    foreach (string finish in _superRightCorner)
                    {
                        string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
                        Console.WriteLine(sectionMetDriver);
                    }
                }
                if (sect.SectionType == SectionTypes.LeftCorner)
                {
                    foreach (string finish in _leftCorner)
                    {
                        string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
                        Console.WriteLine(sectionMetDriver);
                    }
                }
                if (sect.SectionType == SectionTypes.SuperLeftCorner)
                {
                    foreach (string finish in _superLeftCorner)
                    {
                        string sectionMetDriver = PlaceDriver(finish, driverLeft, driverRightt);
                        Console.WriteLine(sectionMetDriver);
                    }
                }
            }
        }

        public static string PlaceDriver(string s, IParticipant leftDriver, IParticipant rightDriver)
        {
            s = s.Replace("<", "L");
            s = s.Replace(">", "R");
            return s;
        }

    }
}

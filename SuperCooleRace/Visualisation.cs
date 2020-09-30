using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCooleRace
{
    public static class Visualisation
    {


        public static void Initialize()
        {

        }

        #region graphics
        private static string[] _finishHorizontal = { "----", " # ", " # ", "----" };
        private static string[] _finishVertical = { "|  |", "|##|", "|  |", "|  |" };
        private static string[] _startHorizontal = { "----", " 8 ", " 8 ", "----" };
        private static string[] _startVertical = { "|  |", "|88|", "|  |", "|  |" };
        private static string[] _straightHorizontal = {"----", "    ", "    ", "----" };
        private static string[] _straightVertical = {"|  |", "|  |", "|  |", "|  |" };
        private static string[] _rightCorner = {"----", "   |", "   |", "-  |" };
        private static string[] _superRightCorner = {"|  -", "|   ", "|   ", "----" };
        private static string[] _leftCorner = {"-  |", "   |", "   |", "----" };
        private static string[] _superLeftCorner = {"----", "|   ", "|   ", "|  -" };


        #endregion

        public static void DrawTrack(Track track)
        {
            foreach(Section sect in track.Sections)
            {
                if(sect.SectionType == SectionTypes.Finish)
                {
                    foreach (string finish in _finishHorizontal)
                    {
                        Console.WriteLine(finish);
                    }
                }
                if (sect.SectionType == SectionTypes.FinishVertical)
                {
                    foreach (string finish in _finishVertical)
                    {
                        Console.WriteLine(finish);
                    }
                }
                if (sect.SectionType == SectionTypes.StartGrid)
                {
                    foreach (string finish in _startHorizontal)
                    {
                        Console.WriteLine(finish);
                    }
                }
                if (sect.SectionType == SectionTypes.StartVertical)
                {
                    foreach (string finish in _startVertical)
                    {
                        Console.WriteLine(finish);
                    }
                }
                if (sect.SectionType == SectionTypes.Straight)
                {
                    foreach (string finish in _straightHorizontal)
                    {
                        Console.WriteLine(finish);
                    }
                }
                if (sect.SectionType == SectionTypes.StraightVertical)
                {
                    foreach (string finish in _straightVertical)
                    {
                        Console.WriteLine(finish);
                    }
                }
                if (sect.SectionType == SectionTypes.RightCorner)
                {
                    foreach (string finish in _rightCorner)
                    {
                        Console.WriteLine(finish);
                    }
                }
                if (sect.SectionType == SectionTypes.SuperRightCorner)
                {
                    foreach (string finish in _superRightCorner)
                    {
                        Console.WriteLine(finish);
                    }
                }
                if (sect.SectionType == SectionTypes.LeftCorner)
                {
                    foreach (string finish in _leftCorner)
                    {
                        Console.WriteLine(finish);
                    }
                }
                if (sect.SectionType == SectionTypes.SuperLeftCorner)
                {
                    foreach (string finish in _superLeftCorner)
                    {
                        Console.WriteLine(finish);
                    }
                }
            }
        }

    }
}

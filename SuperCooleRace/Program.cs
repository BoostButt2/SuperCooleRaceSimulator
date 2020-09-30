using System;
using System.Threading;
using Controller;
using Model;

namespace SuperCooleRace
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello Sperms!");

            //Data.Initialize();
            //Data.NextRace();

            //Console.WriteLine($"Track: {Data.CurrentRace.Track.Name}");

            //for(int i = 0; i > 3; i++)
            //{
            //    Thread.Sleep(100);
            //}

            SectionTypes[] sections = { SectionTypes.StartGrid, SectionTypes.Straight, SectionTypes.RightCorner, SectionTypes.LeftCorner, SectionTypes.Straight, SectionTypes.SuperRightCorner, SectionTypes.SuperLeftCorner, SectionTypes.Finish };

            Track simpleTrack = new Track("Simple track", sections);

            Visualisation.DrawTrack(simpleTrack);

        }
    }
}

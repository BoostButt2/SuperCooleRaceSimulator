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

            SectionTypes[] sections = { SectionTypes.SuperLeftCorner, SectionTypes.Finish, SectionTypes.StartGrid, SectionTypes.RightCorner, SectionTypes.NextLine, SectionTypes.SuperRightCorner, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.LeftCorner, SectionTypes.NextLine };

            Track simpleTrack = new Track("Simple track", sections);

            SectionTypes[] testSections = {SectionTypes.Finish, SectionTypes.Straight, SectionTypes.StartGrid, SectionTypes.NextLine, SectionTypes.RightCorner };
            Track testTrack = new Track("Test track", testSections);

            Visualisation.DrawTrack(testTrack);
            Console.WriteLine("________________________________________________________________");

            Visualisation.DrawTrackTest(simpleTrack);

        }
    }
}

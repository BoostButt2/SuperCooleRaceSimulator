using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Timers;
using Controller;
using Model;

namespace SuperCooleRace
{
    public delegate string p();
    class Program
    {

        private static System.Timers.Timer timer;
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

            SectionTypes[] properSections = { SectionTypes.StartGrid, SectionTypes.StartGrid, SectionTypes.RightCorner, SectionTypes.StraightVertical, SectionTypes.LeftCorner, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.SuperRightCorner, SectionTypes.StraightVertical, SectionTypes.SuperLeftCorner, SectionTypes.Finish };
            //SectionTypes[] testSections = { SectionTypes.StartGrid, SectionTypes.StartGrid, SectionTypes.RightCorner, SectionTypes.StraightVertical, SectionTypes.LeftCorner, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.SuperRightCorner, SectionTypes.StraightVertical, SectionTypes.SuperLeftCorner, SectionTypes.Finish };
            Track properTrack = new Track("Proper racetrack", properSections);
            //Track testTrack = new Track("Test racetrack", testSections);

            Driver dimitri = new Driver("Dimitri");
            Driver totoro = new Driver("Totoro");
            Driver megumin = new Driver("Megumin");

            List<IParticipant> drivers = new List<IParticipant>();
            drivers.Add(dimitri);
            drivers.Add(totoro);
            drivers.Add(megumin);
            Race testRace = new Race(properTrack, drivers);

            //Visualisation.DrawTrack(properTrack);
            Visualisation.StartRace();


            while (true)
            {
            }

        }
        private static void SetTimer()
        {
            timer = new System.Timers.Timer(750);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Start();
        }

                    static void OnTimedEvent(object sender, ElapsedEventArgs e)
            {
                Console.WriteLine("banana");
            }

    }
}

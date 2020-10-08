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

            SectionTypes[] sections = { SectionTypes.SuperLeftCorner, SectionTypes.Finish, SectionTypes.StartGrid, SectionTypes.RightCorner, SectionTypes.NextLine, SectionTypes.SuperRightCorner, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.LeftCorner, SectionTypes.NextLine };
            SectionTypes[] properSections = { SectionTypes.StartGrid, SectionTypes.RightCorner, SectionTypes.LeftCorner, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.SuperRightCorner, SectionTypes.SuperLeftCorner, SectionTypes.Finish };

            Track simpleTrack = new Track("Simple track", sections);
            Track properTrack = new Track("proper", properSections)
                ;
            Driver dimitri = new Driver("Dimitri");
            Driver totoro = new Driver("Totoro");

            List<IParticipant> drivers = new List<IParticipant>();
            drivers.Add(dimitri);
            drivers.Add(totoro);
            Race testRace = new Race(properTrack, drivers);
            testRace.ProperTrack = properTrack;
            Visualisation.driverLeft = dimitri;
            Visualisation.driverRightt = totoro;

            Visualisation.DrawTrack(simpleTrack);
            //Visualisation.StartRace();


            while (true)
            {
                Thread.Sleep(200);
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

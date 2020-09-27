using System;
using System.Threading;
using Controller;

namespace SuperCooleRace
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Sperms!");

            Data.Initialize();
            Data.NextRace();

            Console.WriteLine($"Track: {Data.CurrentRace.Track.Name}");

            for(int i = 0; i > 3; i++)
            {
                Thread.Sleep(100);
            }

        }
    }
}

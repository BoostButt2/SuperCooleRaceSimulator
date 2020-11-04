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


            Data.Initialize();
            Data.NextRace();
            Visualisation.StartRace();

            while (true)
            {

            }

        }

    }
}

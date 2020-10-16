using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Driver : IParticipant
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public string DriverDude { get; set; }

        //De positie in de section List van Track
        public int Position { get; set; }

        //Dit zijn de laps die de driver heeft gemaakt
        public int Lap { get; set; }

        //Hierin bevinden zich de punten van de driver
        public Results Result { get; set; }

        //Hierin bevindt zich de rondetijd van de driver
        public Laptime laptime { get; set; }

        //De positie waar de driver is geëndigd
        public int Podium { get; set; }
        public IEquipment Equipment { get; set; }
        public TeamColors TeamColor { get; set; }

        public Driver(string name)
        {
            this.Name = name;
            this.Lap = 0;
            Equipment = new Car(0, 0, 0, false);
            Result = new Results();
            laptime = new Laptime();
        }
    }
}

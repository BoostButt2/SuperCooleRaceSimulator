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

        public int Lap { get; set; }
        public IEquipment Equipment { get; set; }
        public TeamColors TeamColor { get; set; }

        public Driver(string name)
        {
            this.Name = name;
            this.Lap = 0;
            Equipment = new Car(0, 0, 0, false);
        }
    }
}

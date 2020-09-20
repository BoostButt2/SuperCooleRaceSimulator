using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    class Car : IEquipment
    {
        public int Quality { get; set; }
        public int Performance { get; set; }
        public int Speed { get; set; }
        public bool IsBroken { get; set; }

        public Car(int quality, int performance, int speed, bool isBroken)
        {
            this.Quality = quality;
            this.Performance = performance;
            this.Speed = speed;
            this.IsBroken = isBroken;
        }

    }
}

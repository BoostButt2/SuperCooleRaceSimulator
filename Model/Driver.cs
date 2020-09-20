using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    class Driver : IParticipant
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public IEquipment Equipment { get; set; }
        public IParticipant.TeamColors TeamColor { get; set; }

        public Driver(string name, int points, IEquipment equipment)
        {
            this.Name = name;
            this.Points = points;
            this.Equipment = equipment;
        }
    }
}

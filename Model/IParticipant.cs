using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    //Teamkleuren wijken af van origineel
    public enum TeamColors
    {
        Pink,
        Lime,
        Orange,
        Blue
    }
    public interface IParticipant
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public IEquipment Equipment { get; set; }
        public TeamColors TeamColor { get; set; }



    }
}

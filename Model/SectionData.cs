using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class SectionData
    {        
        public IParticipant Left { get; set; }
        //Niks gedaan met de distance want ik snapte het niet
        public int DistanceLeft { get; set; }
        public IParticipant Right { get; set; }
        public int DistanceRight { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Competition
    {
        public List<IParticipant> Participants { get; set; }
        public Queue<Track> Tracks = new Queue<Track>();

        public Track NextTrack()
        {
            return Tracks[];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Competition
    {
        public List<IParticipant> Participants = new List<IParticipant>();
        public Queue<Track> Tracks = new Queue<Track>();

        public Track NextTrack()
        {
            try
            {
                return Tracks.Dequeue();
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}

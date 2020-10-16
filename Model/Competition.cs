using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Competition
    {
        public List<IParticipant> Participants = new List<IParticipant>();
        public Queue<Track> Tracks = new Queue<Track>();
        public object RaceInfo { get; set; }

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

        public void givePoints(List<Driver> driver)
        {
            foreach(Driver poopoo in driver)
            {
                if(poopoo.Podium == 1)
                {
                    poopoo.Points = 5;
                    poopoo.Result.Points = 5;
                }

                if (poopoo.Podium == 2)
                {
                    poopoo.Points = 3;
                    poopoo.Result.Points = 3;
                }

                if (poopoo.Podium == 3)
                {
                    poopoo.Points = 1;
                    poopoo.Result.Points = 1;
                }

                if (poopoo.Podium == 0)
                {

                }
                poopoo.Result.Name = poopoo.Name;
            }
        }

    }
}

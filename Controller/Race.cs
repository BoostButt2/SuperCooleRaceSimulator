using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    public class Race
    {
        public Track Track { get; set; }
        public List<IParticipant> Participants = new List<IParticipant>();
        public DateTime StartTime { get; set; }

        private Random _random;
        private Dictionary<Section, SectionData> _positions;

        public SectionData sectionData = new SectionData();

        public Race(Track t, List<IParticipant> IP)
        {
            this.Track = t;
            
            for(int i = 0; i < this.Participants.Count; i++)
            {
                this.Participants[i] = IP[i];
            }
            foreach(Driver driver in IP)
            {
                placeParticipant(t, driver);
            }

            _random = new Random(DateTime.Now.Millisecond);
        }

        public SectionData GetSectionData(Section s)
        {
            try
            {
                return _positions[s];
            }
            catch(Exception e)
            {
                _positions.Add(s, new SectionData());
                return _positions[s];
            }
        }

        public void RandomizeEquipment()
        {
            foreach(IParticipant driver in Data.competition.Participants)
            {
                driver.Equipment.Quality = _random.Next();
                driver.Equipment.Performance = _random.Next();
            }
        }


        //kijk of er een startgrid is, 
        public void placeParticipant(Track track, Driver participant)
        {
            if (sectionData.Left == null)
            {
                sectionData.Left = participant;
            }
            if (sectionData.Left != null)
            {
                sectionData.Right = participant;
            }
            foreach (Section sect in track.Sections)
            {
                if (sect.SectionType == SectionTypes.StartGrid || sect.SectionType == SectionTypes.StartVertical)
                {
                    _positions.Add(sect, sectionData);
                }
            }
        }

    }

}
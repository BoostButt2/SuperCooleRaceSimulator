using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;

namespace Controller
{
    public delegate void TimerEvent(object sender, EventArgs eventArgs);
    public delegate void DriverEvent(object sender, DriversChangedEventArgs eventArgs);
    public class Race
    {
        public Track Track { get; set; }
        public List<IParticipant> Participants = new List<IParticipant>();
        public DateTime StartTime { get; set; }

        private Random _random;
        private Dictionary<Section, SectionData> _positions;

        public SectionData sectionData = new SectionData();

        public System.Timers.Timer timer;

        private Section currentSection { get; set; }

        public event TimerEvent TimerOn;
        public event DriverEvent Driverschanged;

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

            timer = new System.Timers.Timer();
            timer.Interval = 500;

            timer.Elapsed += OnTimedEvent;

            //Zorgt ervoor dat de racers beginnen bij de startgrid
            foreach(Section sect in t.Sections)
            {
                if(sect.SectionType == SectionTypes.StartGrid)
                {
                    currentSection = sect;
                }
            }
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

        public void Start()
        {
            timer.Start();
        }
        
        public void OnTimedEvent(object sender, EventArgs eventArgs)
        {
        }

        public void MoveDrivers()
        {
            int teller = 0;
            Section[] sectionArray = Track.Sections.ToArray();
            Queue<Section> hulpQueue = new Queue<Section>();
            List<Section> jankyHulpList = new List<Section>();

            //De array wordt omgezet naar een queue
            foreach(Section sect in sectionArray)
            {
                hulpQueue.Enqueue(sect);
            }

            //Alle sectiontypes die voor de
            foreach (Section peter in sectionArray)
            {
                if (peter.SectionType != SectionTypes.StartGrid)
                {
                    teller++;
                }
                else
                {
                    break;
                }
            }

            //De sectiontypes die niet vooraan horen worden achteraan gezet
            for(int i = 0; i < teller; i++)
            {
                hulpQueue.Enqueue(hulpQueue.Dequeue());
            }

            //De hulpQueue wordt in een list gestopt zodat die in sectionArray gestopt kan worden
            int queueGrootte = hulpQueue.Count;
            for(int i = 0; i < queueGrootte; i++)
            {
                jankyHulpList.Add(hulpQueue.Dequeue());
            }

            sectionArray = jankyHulpList.ToArray();


            for (int i = 0; i < sectionArray.Length; i++)
            {
                if(currentSection.SectionType == sectionArray[i].SectionType)
                {
                    currentSection = sectionArray[i + 1];
                }
            }
        }

    }

}
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Transactions;

namespace Controller
{
    public delegate void TimerEvent(object sender, EventArgs eventArgs);
    public delegate void DriverEvent(object sender, DriversChangedEventArgs eventArgs);
    public class Race
    {
        public Track Track { get; set; }
        public Track ProperTrack { get; set; }
        public List<IParticipant> Participants = new List<IParticipant>();
        public DateTime StartTime { get; set; }

        private int lap = 0;

        private Random _random;
        public Dictionary<Section, SectionData> _positions = new Dictionary<Section, SectionData>();

        public SectionData sectionData = new SectionData();

        private System.Timers.Timer timer;

        public int currentSection { get; set; }

        public event DriverEvent Driverschanged;


        private DriversChangedEventArgs driversChangedEventArgs = new DriversChangedEventArgs();

        public Race(Track t, List<IParticipant> IP)
        {
            Data.CurrentRace = this;
            this.Track = t;
            driversChangedEventArgs.track = t;

            currentSection = 0;

            //Plaatst elke racer op de startgrid
            int teller = 0;
            foreach(Driver participant in IP)
            {
                if(teller < 2)
                {
                    participant.Position = 1;
                }
                else
                {
                    participant.Position = 0;
                }
                Participants.Add(participant);
            }

            foreach(Section sect in t.Sections)
            {
                GetSectionData(sect);
            }

            _random = new Random(DateTime.Now.Millisecond);
            SetTimer();
        }

        public void SetTimer()
        {
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
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
        
        public void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            if(lap == 2)
            {
                Console.WriteLine("Iemand wint!");
                timer.Enabled = false;
                return;
               
            }

            MoveCurrentSection();

            Driverschanged(sender, driversChangedEventArgs);

        }

        //public void SortSections()
        //{
        //    int teller = 0;
        //    int nextLineTeller = 1;
        //    _sectionArray = Track.Sections.ToArray();
        //    Queue<Section> hulpQueue = new Queue<Section>();
        //    Stack<Section> hulpStack = new Stack<Section>();
        //    List<Section> jankyHulpList = new List<Section>();

        //    //De array wordt omgezet naar een queue
        //    foreach(Section sect in _sectionArray)
        //    {
        //        if(sect.SectionType == SectionTypes.NextLine)
        //        {
        //            nextLineTeller++;
        //        }
        //        if(nextLineTeller % 2 == 0 && sect.SectionType != SectionTypes.NextLine && sect.SectionType != SectionTypes.EmptyField)
        //        {
        //            hulpStack.Push(sect);
        //        }
        //        if (nextLineTeller % 2 != 0 && sect.SectionType != SectionTypes.NextLine && sect.SectionType != SectionTypes.EmptyField)
        //        {
        //            hulpQueue.Enqueue(sect);
        //        }

        //    }

        //    //Alle sectiontypes die voor de
        //    foreach (Section peter in _sectionArray)
        //    {
        //        if (peter.SectionType != SectionTypes.StartGrid)
        //        {
        //            teller++;
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }


        //    //De hulpQueue wordt in een list gestopt zodat die in sectionArray gestopt kan worden
        //    int queueGrootte = hulpQueue.Count + hulpStack.Count;
        //    nextLineTeller = 0;
        //    for(int i = teller; i < queueGrootte; i++)
        //    {
        //        if(_sectionArray[i].SectionType == SectionTypes.NextLine)
        //        {
        //            nextLineTeller++;
        //        }
        //        if(_sectionArray[i].SectionType != SectionTypes.NextLine && _sectionArray[i].SectionType != SectionTypes.EmptyField && nextLineTeller % 2 == 0)
        //        {
        //            jankyHulpList.Add(hulpStack.Pop());
        //        }

        //        if (_sectionArray[i].SectionType != SectionTypes.NextLine && _sectionArray[i].SectionType != SectionTypes.EmptyField && nextLineTeller % 2 != 0)
        //        {

        //            jankyHulpList.Add(hulpQueue.Dequeue());
        //        }
        //    }
        //    //De sectiontypes die niet vooraan horen worden achteraan gezet
        //    for (int i = 0; i < teller; i++)
        //    {
        //        jankyHulpList.Add(hulpQueue.Dequeue());
        //    }

        //    _sectionArray = jankyHulpList.ToArray();

        //    foreach(Section s in _sectionArray)
        //    {
        //        Console.WriteLine(s.SectionType);
        //    }
        //}

        int sectionTeller = 0;
        int participantTeller = 0;
        public void MoveCurrentSection()
        {
            foreach(KeyValuePair<Section, SectionData> entry in _positions)
            {
                entry.Value.Left = null;
                entry.Value.Right = null;
            }
            
            if (currentSection == Track.Sections.Count - 1)
            {
                currentSection = 0;
                lap++;

            }

            else
            {
                foreach (Driver participant in Participants)
                {
                    int speed = _random.Next();
                    if (speed > 100 && speed < 900)
                    {
                        participant.Position++;
                    }
                    if (speed >= 900)
                    {
                        participant.Position += 2;
                    }
                    Section[] sections = Track.Sections.ToArray();
                    if(participantTeller %2 == 0)
                    {
                        if (_positions[sections[sectionTeller]].Left == null)
                        {
                            _positions[sections[sectionTeller]].Left = participant;
                        }
                    }

                    if (participantTeller % 2 != 0)
                    {
                        if (_positions[sections[sectionTeller]].Right == null)
                        {
                            _positions[sections[sectionTeller]].Right = participant;
                        }

                    }
                    participantTeller++;
                }
                currentSection++;
            }
            //sectionTeller++;
            //_sectionArray = Track.Sections.ToArray();
            //currentSection = _sectionArray[sectionTeller];

            //if (currentSection.SectionType == SectionTypes.Finish)
            //{
            //    sectionTeller = -1;
            //}

            //for (int i = 0; i < _sectionArray.Length; i++)
            //{
            //    if (currentSection.SectionType == _sectionArray[i].SectionType)
            //    {
            //        currentSection = _sectionArray[i + 1];
            //        break;
            //    }
            //}
        }

    }

}
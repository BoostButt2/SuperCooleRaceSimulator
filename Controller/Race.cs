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

        private Random _random;
        private Dictionary<Section, SectionData> _positions;

        public SectionData sectionData = new SectionData();

        private System.Timers.Timer timer;

        public Section currentSection { get; set; }

        public event TimerEvent TimerOn;
        public event DriverEvent Driverschanged;

        private Section[] _sectionArray;

        private DriversChangedEventArgs driversChangedEventArgs = new DriversChangedEventArgs();

        public Race(Track t, List<IParticipant> IP)
        {
            Data.CurrentRace = this;
            this.Track = t;
            driversChangedEventArgs.track = t;

            //for (int i = 0; i < this.Participants.Count; i++)
            //{
            //    this.Participants[i] = IP[i];
            //}
            //foreach(Driver driver in IP)
            //{
            //    placeParticipant(t, driver);
            //}

            //Zorgt ervoor dat de racers beginnen bij de startgrid
            foreach (Section sect in t.Sections)
            {
                if (sect.SectionType == SectionTypes.StartGrid)
                {
                    currentSection = sect;
                }
            }

            //SortSections();

            _random = new Random(DateTime.Now.Millisecond);
            SetTimer();
        }

        public void SetTimer()
        {
            timer = new System.Timers.Timer(2000);
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
        public void MoveCurrentSection()
        {
            sectionTeller++;
            _sectionArray = ProperTrack.Sections.ToArray();
            currentSection = _sectionArray[sectionTeller];

            if (currentSection.SectionType == SectionTypes.Finish)
            {
                sectionTeller = -1;
            }

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
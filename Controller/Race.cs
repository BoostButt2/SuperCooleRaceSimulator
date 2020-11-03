using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Transactions;

namespace Controller
{
    public delegate void TimerEvent(object sender, EventArgs eventArgs);
    public delegate void DriverEvent(object sender, EventArgs eventArgs);
    public delegate Dictionary<string, int> RaceFinishedEvent(Dictionary<string, int> score);
    public delegate void StartNewRaceEvent();
    public class Race
    {
        public Track Track { get; set; }
        public List<Driver> Participants = new List<Driver>();
        public DateTime StartTime { get; set; }

        private Random _random;
        public Dictionary<Section, SectionData> _positions = new Dictionary<Section, SectionData>();

        public SectionData sectionData = new SectionData();

        private System.Timers.Timer timer;

        public event DriverEvent Driverschanged;

        //Zorgt ervoor dat er een tweede race wordt aangeroepen als de huidige race voorbij is
        public event StartNewRaceEvent NewRaceEvent;

        private int baanTeller = 1;
        public bool raceStoppen = false;

        private int place = 0;
        private Stopwatch time = new Stopwatch();

        private DriversChangedEventArgs driversChangedEventArgs = new DriversChangedEventArgs();
        private List<Driver> eindstand = new List<Driver>();
        public Queue<Driver> driverInOrder = new Queue<Driver>();
        public bool KondigAan = false;

        public List<int> TestList = new List<int>();
        
        public Race(Track t, List<IParticipant> IP)
        {
            Data.CurrentRace = this;
            this.Track = t;
            driversChangedEventArgs.track = t;

            //Vult de _positions dictionary
            foreach (Section sect in t.Sections)
            {
                GetSectionData(sect);
            }

            //Plaatst elke racer op de startgrid
            int teller = 0;
            Section[] hulpArray = Track.Sections.ToArray();
            foreach(Driver participant in IP)
            {                
                if(teller < 2)
                {
                    participant.Position = 1;
                    if (_positions[hulpArray[1]].Left == null)
                    {
                        _positions[hulpArray[1]].Left = participant;
                    }

                    else if (_positions[hulpArray[1]].Right == null)
                    {
                        _positions[hulpArray[1]].Right = participant;
                    }

                }
                else
                {
                    participant.Position = 0;
                    if (_positions[hulpArray[0]].Left == null)
                    {
                        _positions[hulpArray[0]].Left = participant;
                    }

                    else if (_positions[hulpArray[0]].Right == null)
                    {
                        _positions[hulpArray[0]].Right = participant;
                    }
                }
                Participants.Add(participant);
                teller++;
            }

            _random = new Random(DateTime.Now.Millisecond);
            SetTimer();
        }

        public void SetTimer()
        {
            timer = new System.Timers.Timer(500);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
            Stopwatch.StartNew();
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
                if (sect.SectionType == SectionTypes.StartGrid)
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
            foreach(Driver participant in Participants)
            {
                Random random = new Random();
                int broken = random.Next(1, 13);
                int notBroken = random.Next(1, 2);
                if(broken == 4)
                {
                    participant.Equipment.IsBroken = true;
                }
                else if(notBroken == 1)
                {
                    participant.Equipment.IsBroken = false;
                }
            }


            MoveCurrentSection();

            baanTeller = 0;

            //Kijkt of er nog iemand op de baan is
            foreach (KeyValuePair<Section, SectionData> entry in _positions)
            {
                if (entry.Value.Right != null || entry.Value.Left != null)
                {
                    baanTeller++;
                }
            }

            if(baanTeller == 0)
            {
                KondigAan = true;
            }


            Driverschanged(sender, driversChangedEventArgs);

            //Als her niemand op de baan is, wordt de timed event stopgezet
            if (baanTeller == 0)
            {
                if (raceStoppen)
                {
                    Driverschanged = delegate { };
                    timer.Enabled = false;
                    Data.competition.givePoints(getEindstand());
                    Data.SetScores();
                }
                else
                {
                    Driverschanged = delegate { };
                    timer.Enabled = false;
                    time.Stop();

                    Data.competition.givePoints(getEindstand());
                    Data.SetScores();

                    Data.Initialize();
                    Data.NextRace();
                    Data.CurrentRace.raceStoppen = true;
                    NewRaceEvent();
                }

            }

        }

        public List<Driver> getEindstand()
        {
            foreach(Driver participant in Data.CurrentRace.Participants)
            {                
                eindstand.Add(participant);
            }
            return eindstand;
        }

        public void MoveCurrentSection()
        {
            //Maakt alle posities van alle sections leeg
            foreach(KeyValuePair<Section, SectionData> entry in _positions)
            {
                entry.Value.Left = null;
                entry.Value.Right = null;
            }

            
            foreach (Driver participant in Participants)
            {
                if (participant.Equipment.IsBroken == false)
                {
                    //Bepaalt hoeveel stappen een racer mag zetten
                    int speed = new Random().Next(0, 999);
                    Random random = new Random();
                    if (speed < 900)
                    {
                        participant.Position += random.Next(1, 3);
                    }

                    if (speed >= 900)
                    {
                        participant.Position += 2;
                    }
                }


                //Als de racer een hele lap heeft gemaakt, moet hij beginnen aan een nieuwe lap
                if (participant.Position > Track.Sections.Count - 1)
                {
                    participant.Position = participant.Position - (Track.Sections.Count - 1);
                    participant.Lap++;

                }

                if (participant.Lap < 2)
                {
                    Section[] sections = Track.Sections.ToArray();

                    if (_positions[sections[participant.Position]].Left == null)
                    {
                        _positions[sections[participant.Position]].Left = participant;
                    }

                    else if (_positions[sections[participant.Position]].Right == null)
                    {
                        _positions[sections[participant.Position]].Right = participant;
                    }

                    else if (_positions[sections[participant.Position]].Right != null && _positions[sections[participant.Position]].Left != null)
                    {
                        participant.Position++;

                        if (_positions[sections[participant.Position]].Left == null)
                        {
                            _positions[sections[participant.Position]].Left = participant;
                        }

                        else
                        {
                            _positions[sections[participant.Position]].Right = participant;
                        }

                    }

                }

                else if(participant.Lap == 2 && participant.Podium == 0)
                {
                    place += 1;
                    if (place == 1)
                    {
                        participant.Podium = place;
                    }
                    if (place == 2)
                    {
                        participant.Podium = place;
                    }
                    if (place == 3)
                    {
                        participant.Podium = place;
                    }
                    else
                    {
                        participant.Podium = place;
                    }
                    time.Stop();
                    participant.laptime.Time = time.Elapsed;
                    time.Start();

                    participant.laptime.Name = participant.Name;
                    driverInOrder.Enqueue(participant);
                }
            }

        }

    }

}
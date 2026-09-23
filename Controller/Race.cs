using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Timers;

namespace Controller
{
    public delegate void TimerEvent(object sender, EventArgs eventArgs);
    public delegate void DriverEvent(object sender, EventArgs eventArgs);
    public delegate Dictionary<string, int> RaceFinishedEvent(Dictionary<string, int> score);
    public delegate void StartNewRaceEvent();

    public class Race
    {
        // Constants
        private const int TimerIntervalMs = 500;
        private const int MaxLaps = 2;
        private const int StartGridCount = 2;
        private const int BreakdownLowChance = 4;
        private const int BreakdownHighChance = 9;
        private const int RepairChanceMin = 3;
        private const int RepairChanceMax = 6;
        private const int SpeedHighThreshold = 900;
        private const int SpeedRange = 999;
        private const int HighSpeedBonus = 2;

        // Properties
        public Track Track { get; set; }
        public List<Driver> Participants { get; set; } = new List<Driver>();
        public DateTime StartTime { get; set; }
        public Dictionary<Section, SectionData> Positions { get; set; } = new Dictionary<Section, SectionData>();
        public System.Timers.Timer Timer { get; set; }
        public Queue<Driver> DriversInOrder { get; set; } = new Queue<Driver>();

        // Events
        public event DriverEvent DriversChanged;
        public event StartNewRaceEvent NewRaceEvent;

        // Private Fields
        private readonly Random _random;
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private readonly DriversChangedEventArgs _driversChangedEventArgs = new DriversChangedEventArgs();
        private readonly List<Driver> _finalStandings = new List<Driver>();
        private int _activeDriverCount = 0;
        private int _finishPlace = 0;
        private bool _shouldStopRace = false;
        public bool KondigAan { get; set; } = false;
        public Race(Track track, List<IParticipant> participants)
        {
            Data.CurrentRace = this;
            Track = track;
            _driversChangedEventArgs.track = track;
            _random = new Random(DateTime.Now.Millisecond);

            InitializePositions(track);
            PlaceParticipantsOnGrid(track, participants);
            SetTimer();
            _stopwatch.Start();
        }

        private void InitializePositions(Track track)
        {
            foreach (Section section in track.Sections)
            {
                GetSectionData(section);
            }
        }

        private void PlaceParticipantsOnGrid(Track track, List<IParticipant> participants)
        {
            Section[] sections = track.Sections.ToArray();
            int count = 0;

            foreach (Driver participant in participants)
            {
                if (count < StartGridCount)
                {
                    participant.Position = 1;
                    PlaceDriverInSection(sections[1], participant);
                }
                else
                {
                    participant.Position = 0;
                    PlaceDriverInSection(sections[0], participant);
                }
                
                Participants.Add(participant);
                count++;
            }
        }

        private void PlaceDriverInSection(Section section, Driver participant)
        {
            SectionData sectionData = GetSectionData(section);
            
            if (sectionData.Left == null)
            {
                sectionData.Left = participant;
            }
            else if (sectionData.Right == null)
            {
                sectionData.Right = participant;
            }
        }

        public void SetTimer()
        {
            Timer = new System.Timers.Timer(TimerIntervalMs);
            Timer.Elapsed += OnTimedEvent;
            Timer.AutoReset = true;
            Timer.Enabled = true;
        }

        public SectionData GetSectionData(Section section)
        {
            if (Positions.ContainsKey(section))
            {
                return Positions[section];
            }

            Positions.Add(section, new SectionData());
            return Positions[section];
        }

        public void RandomizeEquipment()
        {
            foreach (IParticipant driver in Data.competition.Participants)
            {
                driver.Equipment.Quality = _random.Next();
                driver.Equipment.Performance = _random.Next();
            }
        }

        public void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            UpdateEquipmentStatus();
            MoveCurrentSection();
            UpdateActiveDriverCount();

            DriversChanged?.Invoke(sender, _driversChangedEventArgs);

            if (_activeDriverCount == 0)
            {
                EndRace();
            }
        }

        private void UpdateEquipmentStatus()
        {
            foreach (Driver participant in Participants)
            {
                int breakdownChance = _random.Next(1, 13);
                int repairChance = _random.Next(1, 10);

                if (breakdownChance == BreakdownLowChance || breakdownChance == BreakdownHighChance)
                {
                    participant.Equipment.IsBroken = true;
                }
                else if (repairChance >= RepairChanceMin && repairChance <= RepairChanceMax)
                {
                    participant.Equipment.IsBroken = false;
                }
            }
        }

        private void UpdateActiveDriverCount()
        {
            _activeDriverCount = 0;
            foreach (KeyValuePair<Section, SectionData> entry in Positions)
            {
                if (entry.Value.Right != null || entry.Value.Left != null)
                {
                    _activeDriverCount++;
                }
            }
        }

        private void EndRace()
        {
            Timer.Enabled = false;
            DriversChanged = null;
            _stopwatch.Stop();
            KondigAan = true;
            Data.competition.givePoints(GetFinalStandings());
            Data.SetScores();

            if (!_shouldStopRace)
            {
                Data.Initialize();
                Data.NextRace();
                Data.CurrentRace._shouldStopRace = true;
                NewRaceEvent?.Invoke();
            }
        }

        public List<Driver> GetFinalStandings()
        {
            foreach (Driver participant in Data.CurrentRace.Participants)
            {
                _finalStandings.Add(participant);
            }
            return _finalStandings;
        }

        private void MoveCurrentSection()
        {
            ClearAllPositions();
            MoveAllDrivers();
        }

        private void ClearAllPositions()
        {
            foreach (KeyValuePair<Section, SectionData> entry in Positions)
            {
                entry.Value.Left = null;
                entry.Value.Right = null;
            }
        }

        private void MoveAllDrivers()
        {
            Section[] sections = Track.Sections.ToArray();

            foreach (Driver participant in Participants)
            {
                if (!participant.Equipment.IsBroken)
                {
                    MoveDriver(participant);
                }

                if (participant.Lap < MaxLaps)
                {
                    PlaceDriverOnTrack(sections, participant);
                }
                else if (participant.Lap == MaxLaps && participant.Podium == 0)
                {
                    FinishDriver(participant);
                }
            }
        }

        private void MoveDriver(Driver participant)
        {
            int speed = _random.Next(0, SpeedRange + 1);
            
            if (speed >= SpeedHighThreshold)
            {
                participant.Position += HighSpeedBonus;
            }
            else
            {
                participant.Position += _random.Next(1, 3);
            }

            if (participant.Position > Track.Sections.Count - 1)
            {
                participant.Position = participant.Position - (Track.Sections.Count - 1);
                participant.Lap++;
            }
        }

        private void PlaceDriverOnTrack(Section[] sections, Driver participant)
        {
            Section currentSection = sections[participant.Position];
            SectionData sectionData = Positions[currentSection];

            if (sectionData.Left == null)
            {
                sectionData.Left = participant;
            }
            else if (sectionData.Right == null)
            {
                sectionData.Right = participant;
            }
            else
            {
                MoveDriverToNextAvailableSection(sections, participant);
            }
        }

        private void MoveDriverToNextAvailableSection(Section[] sections, Driver participant)
        {
            participant.Position++;
            Section nextSection = sections[participant.Position];
            SectionData nextSectionData = Positions[nextSection];

            if (nextSectionData.Left == null)
            {
                nextSectionData.Left = participant;
            }
            else
            {
                nextSectionData.Right = participant;
            }
        }

        private void FinishDriver(Driver participant)
        {
            _finishPlace++;
            participant.Podium = _finishPlace;
            _stopwatch.Stop();
            participant.laptime.Time = _stopwatch.Elapsed;
            _stopwatch.Start();
            participant.laptime.Name = participant.Name;
            DriversInOrder.Enqueue(participant);
        }
    }
}
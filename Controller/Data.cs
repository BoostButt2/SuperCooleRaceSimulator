using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Model;

namespace Controller
{
    public static class Data
    {
        public static Competition competition { get; set; } = new Competition();
        public static Race CurrentRace { get; set; }
       public static  DriverPoints driverpoints { get; set; } = new DriverPoints();
        public static Laptimes DriverLapTime { get; set; } = new Laptimes();
        public static DriverPlaces DriversInOrder { get; set; } = new DriverPlaces();

        public static void Initialize()
        {
            AddParticipant();
            addTrack();
        }

        public static void SetScores()
        {
            foreach (Driver participant in CurrentRace.Participants)
            {
                Dictionary<string, int> points = new Dictionary<string, int>();
                points.Add(participant.Result.Name, participant.Result.Points);

                Dictionary<string, TimeSpan> time = new Dictionary<string, TimeSpan>();
                time.Add(participant.laptime.Name, participant.laptime.Time);

                Dictionary<string, int> position = new Dictionary<string, int>();
                position.Add(participant.Name, participant.Podium);

                driverpoints.AddList(points);
                DriverLapTime.AddList(time);
                DriversInOrder.AddList(position);
            }
        }

        public static void AddParticipant()
        {
            Driver putin = new Driver("Putin");
            putin.TeamColor = TeamColors.Pink;
            competition.Participants.Add(putin);

            Driver snutin = new Driver("Snutin");
            snutin.TeamColor = TeamColors.Orange;
            competition.Participants.Add(snutin);

            Driver flutin = new Driver("Flutin");
            flutin.TeamColor = TeamColors.Blue;
            competition.Participants.Add(flutin);

            Driver rasputin = new Driver("Rasputin");
            rasputin.TeamColor = TeamColors.Lime;
            competition.Participants.Add(rasputin);

        }

        public static void addTrack()
        {
            SectionTypes[] sections = { SectionTypes.StartGrid, SectionTypes.StartGrid, SectionTypes.Straight, SectionTypes.RightCorner, SectionTypes.StraightVertical, SectionTypes.StraightVertical, SectionTypes.SuperRightCorner, SectionTypes.Straight, SectionTypes.RightCorner, SectionTypes.LeftCorner, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.SuperRightCorner, SectionTypes.StraightVertical, SectionTypes.StraightVertical, SectionTypes.StraightVertical, SectionTypes.SuperLeftCorner, SectionTypes.Finish };

            Track hardTrack = new Track("Hard track", sections);

            competition.Tracks.Enqueue(hardTrack);
        }

        public static void NextRace()
        {
                CurrentRace = new Race(competition.NextTrack(), competition.Participants);            
        }

    }
}

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Model;

namespace Controller
{
    public static class Data
    {
        public static Competition competition { get; set; }
        public static Race CurrentRace { get; set; }

        public static void Initialize()
        {
            competition = new Competition();
            AddParticipant();
            addTrack();
        }

        public static void AddParticipant()
        {
            Driver putin = new Driver("Putin");
            competition.Participants.Add(putin);

            Driver snutin = new Driver("Snutin");
            competition.Participants.Add(snutin);

            Driver flutin = new Driver("Flutin");
            competition.Participants.Add(flutin);

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

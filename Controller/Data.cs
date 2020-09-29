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
            SectionTypes[] sections = { SectionTypes.StartGrid, SectionTypes.Straight, SectionTypes.RightCorner, SectionTypes.RightCorner, SectionTypes.Straight, SectionTypes.RightCorner, SectionTypes.RightCorner, SectionTypes.Finish };

            Track simpleTrack = new Track("Simple track", sections);

            competition.Tracks.Enqueue(simpleTrack);
        }

        public static void NextRace()
        {
            if(competition.NextTrack() != null)
            {
                CurrentRace = new Race(competition.NextTrack(), competition.Participants);
            }
        }

    }
}

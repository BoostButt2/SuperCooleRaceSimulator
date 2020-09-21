using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Controller
{
    static class Data
    {
        public static Competition competition { get; set; }

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
            Section start = new Section(SectionTypes.StartGrid);
            Section straight = new Section(SectionTypes.Straight);
            Section right1 = new Section(SectionTypes.RightCorner);
            Section right2 = new Section(SectionTypes.RightCorner);
            Section straight2 = new Section(SectionTypes.Straight);
            Section right3 = new Section(SectionTypes.RightCorner);
            Section right4 = new Section(SectionTypes.RightCorner);
            Section finish = new Section(SectionTypes.Finish);

            Track simpleTrack = new Track("Simple track");

            simpleTrack.Sections.AddLast(start);
            simpleTrack.Sections.AddLast(straight);
            simpleTrack.Sections.AddLast(right1);
            simpleTrack.Sections.AddLast(right2);
            simpleTrack.Sections.AddLast(straight2);
            simpleTrack.Sections.AddLast(right3);
            simpleTrack.Sections.AddLast(right4);
            simpleTrack.Sections.AddLast(finish);

            competition.Tracks.Enqueue(simpleTrack);
        }

    }
}

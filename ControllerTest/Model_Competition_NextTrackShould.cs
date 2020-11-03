using Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using RaceTrackMooi;

namespace ControllerTest
{
    [TestFixture]
    class Model_Competition_NextTrackShould
    {
        private Competition _competition;
        private SectionTypes[] properSections = { SectionTypes.StartGrid, SectionTypes.StartGrid, SectionTypes.RightCorner, SectionTypes.StraightVertical, SectionTypes.LeftCorner, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.SuperRightCorner, SectionTypes.StraightVertical, SectionTypes.SuperLeftCorner, SectionTypes.Finish };

        private Track testTrack;

        [SetUp]
        public void SetUp()
        {
            _competition = new Competition();
            testTrack = new Track("TestTrack", properSections);

        }

        [Test]
        public void NextTrack_EmptyQueue_ReturnNull()
        {

            Track result = _competition.NextTrack();

            Assert.IsNull(result);

        }

        [Test]
        public void NextTrack_OneInQueue_ReturnTrack()
        {

            _competition.Tracks.Enqueue(testTrack);

            Track result = _competition.NextTrack();
            Assert.AreEqual(testTrack, result);
        }

        [Test]
        public void NextTrack_OneInQueue_RemoveTrackFromQueue()
        {
            Track testTrack2 = new Track("TestTrack2", properSections);
            _competition.Tracks.Enqueue(testTrack2);
            Track result = _competition.NextTrack();
            result = _competition.NextTrack();

            Assert.IsNull(result);
        }

        [Test]
        public void NextTrack_TwoInQueue_ReturnTrack()
        {
            _competition.Tracks.Enqueue(testTrack);

            Track testTrack2 = new Track("TestTrack2", properSections);
            _competition.Tracks.Enqueue(testTrack2);

            Track result = _competition.NextTrack();
            result = _competition.NextTrack();
            Assert.AreEqual(result, testTrack2);
        }
    }
}

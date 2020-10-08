using Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControllerTest
{
    [TestFixture]
    class Model_Competition_NextTrackShould
    {
        private Competition _competition;

        [SetUp]
        public void SetUp()
        {
            _competition = new Competition();
        }

        [Test]
        public void NextTrack_EmptyQueue_ReturnNull()
        {

            Track result = _competition.NextTrack();

            Assert.IsNull(result);

        }

        //[Test]
        //public void NextTrack_OneInQueue_ReturnTrack()
        //{
        //    Track testTrack= new Track("TestTrack");
        //    _competition.Tracks.Enqueue(testTrack);

        //    Track result = _competition.NextTrack();
        //    Assert.AreEqual(testTrack, result);
        //}

        //[Test]
        //public void NextTrack_OneInQueue_RemoveTrackFromQueue()
        //{
        //    Track testTrack2 = new Track("TestTrack2");

        //    _competition.Tracks.Enqueue(testTrack2);
        //    Track result = _competition.NextTrack();
        //    result = _competition.NextTrack();

        //    Assert.IsNull(result);
        //}

        //[Test]
        //public void NextTrack_TwoInQueue_ReturnTrack()
        //{
        //    Track testTrack = new Track("TestTrack");
        //    _competition.Tracks.Enqueue(testTrack);

        //    Track testTrack2 = new Track("TestTrack2");
        //    _competition.Tracks.Enqueue(testTrack2);

        //    Track result = _competition.NextTrack();
        //    result = _competition.NextTrack();
        //    Assert.AreEqual(result, testTrack2);
        //}
    }
}

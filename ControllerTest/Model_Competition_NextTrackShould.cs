using Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using RaceTrackMooi;
using Controller;
using System.Windows.Media.Imaging;
using System.Drawing;

namespace ControllerTest
{
    [TestFixture]
    class Model_Competition_NextTrackShould
    {
        private Competition _competition;
        private SectionTypes[] properSections = { SectionTypes.StartGrid, SectionTypes.StartGrid, SectionTypes.RightCorner, SectionTypes.StraightVertical, SectionTypes.LeftCorner, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.SuperRightCorner, SectionTypes.StraightVertical, SectionTypes.SuperLeftCorner, SectionTypes.Finish };

        private Track testTrack;
        private DataContext dataContext;

        [SetUp]
        public void SetUp()
        {
            _competition = new Competition();
            testTrack = new Track("TestTrack", properSections);
            Data.Initialize();
            Data.NextRace();

            dataContext = new DataContext();
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

        [Test]
        public void GetImages_FillDictionary_NotNull()
        {
            LoadImage.GetImages(@"C:\Users\jesse\School\ICT M3.1\C#\SuperCooleRace\SuperCooleRace\RaceTrackMooi\TrackVisual\Broken.png");

            Assert.IsTrue(LoadImage.Images.Count == 1);
        }

        [Test]
        public void GetImages_ClearCache_Null()
        {
            LoadImage.GetImages(@"C:\Users\jesse\School\ICT M3.1\C#\SuperCooleRace\SuperCooleRace\RaceTrackMooi\TrackVisual\Broken.png");
            LoadImage.ClearCache();

            Assert.IsTrue(LoadImage.Images.Count == 0);
        }

        [Test]
        public void GetEmptyBitmap_FillDictionary_NotNull()
        {
            LoadImage.GetEmptyImage(100, 100);

            Assert.IsTrue(LoadImage.Images.Count != 0);
        }

        [Test]
        public void DrawTrack_IsNotNull()
        {
            Assert.IsTrue(VisualisationMooi.DrawTrack(testTrack) != null);
        }


        
    }
}

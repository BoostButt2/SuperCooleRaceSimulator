using Controller;
using Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControllerTest
{
    [TestFixture]
    public class RaceShould
    {
        private Track _testTrack;
        private List<IParticipant> _testParticipants;
        private Race _race;
        private SectionTypes[] _properSections;

        [SetUp]
        public void SetUp()
        {
            // Initialize Data
            Data.Initialize();

            // Create test track
            _properSections = new[]
            {
                SectionTypes.StartGrid, SectionTypes.StartGrid, SectionTypes.RightCorner,
                SectionTypes.StraightVertical, SectionTypes.LeftCorner, SectionTypes.Straight,
                SectionTypes.Straight, SectionTypes.Straight, SectionTypes.SuperRightCorner,
                SectionTypes.StraightVertical, SectionTypes.SuperLeftCorner, SectionTypes.Finish
            };
            _testTrack = new Track("TestTrack", _properSections);

            // Create test participants
            _testParticipants = new List<IParticipant>
            {
                new Driver { Name = "Driver1" },
                new Driver { Name = "Driver2" },
                new Driver { Name = "Driver3" },
                new Driver { Name = "Driver4" }
            };
        }

        [Test]
        public void Constructor_InitializesRaceWithTrack()
        {
            _race = new Race(_testTrack, _testParticipants);

            Assert.AreEqual(_testTrack, _race.Track);
        }

        [Test]
        public void Constructor_PlacesAllParticipants()
        {
            _race = new Race(_testTrack, _testParticipants);

            Assert.AreEqual(4, _race.Participants.Count);
        }

        [Test]
        public void Constructor_CreatesPositionDictionary()
        {
            _race = new Race(_testTrack, _testParticipants);

            Assert.AreEqual(_testTrack.Sections.Count, _race.Positions.Count);
        }

        [Test]
        public void Constructor_PlacesFirstTwoDriversOnStartGrid()
        {
            _race = new Race(_testTrack, _testParticipants);

            Driver driver1 = _race.Participants[0];
            Driver driver2 = _race.Participants[1];

            Assert.AreEqual(1, driver1.Position);
            Assert.AreEqual(1, driver2.Position);
        }

        [Test]
        public void Constructor_PlacesRemainingDriversBeforeStartGrid()
        {
            _race = new Race(_testTrack, _testParticipants);

            Driver driver3 = _race.Participants[2];
            Driver driver4 = _race.Participants[3];

            Assert.AreEqual(0, driver3.Position);
            Assert.AreEqual(0, driver4.Position);
        }

        [Test]
        public void GetSectionData_ExistingSection_ReturnsSectionData()
        {
            _race = new Race(_testTrack, _testParticipants);
            Section section = _testTrack.Sections.First();

            SectionData result = _race.GetSectionData(section);

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetSectionData_NonExistingSection_CreatesAndReturnsSectionData()
        {
            _race = new Race(_testTrack, _testParticipants);
            Section newSection = new Section(SectionTypes.Straight);

            SectionData result = _race.GetSectionData(newSection);

            Assert.IsNotNull(result);
            Assert.IsTrue(_race.Positions.ContainsKey(newSection));
        }

        [Test]
        public void SetTimer_CreatesTimerWithCorrectInterval()
        {
            _race = new Race(_testTrack, _testParticipants);

            Assert.IsNotNull(_race.Timer);
            Assert.AreEqual(500, _race.Timer.Interval);
        }

        [Test]
        public void SetTimer_EnablesTimer()
        {
            _race = new Race(_testTrack, _testParticipants);

            Assert.IsTrue(_race.Timer.Enabled);
        }

        [Test]
        public void RandomizeEquipment_SetsEquipmentQuality()
        {
            Data.competition = new Competition();
            Data.competition.Participants = new List<IParticipant>
            {
                new Driver { Name = "TestDriver", Equipment = new Car() }
            };

            _race = new Race(_testTrack, _testParticipants);
            _race.RandomizeEquipment();

            foreach (IParticipant participant in Data.competition.Participants)
            {
                Assert.IsTrue(participant.Equipment.Quality >= 0);
            }
        }

        [Test]
        public void RandomizeEquipment_SetsEquipmentPerformance()
        {
            Data.competition = new Competition();
            Data.competition.Participants = new List<IParticipant>
            {
                new Driver { Name = "TestDriver", Equipment = new Car() }
            };

            _race = new Race(_testTrack, _testParticipants);
            _race.RandomizeEquipment();

            foreach (IParticipant participant in Data.competition.Participants)
            {
                Assert.IsTrue(participant.Equipment.Performance >= 0);
            }
        }

        [Test]
        public void GetFinalStandings_ReturnsParticipants()
        {
            _race = new Race(_testTrack, _testParticipants);

            List<Driver> standings = _race.GetFinalStandings();

            Assert.IsNotNull(standings);
        }

        [Test]
        public void DriversInOrder_IsInitiallyEmpty()
        {
            _race = new Race(_testTrack, _testParticipants);

            Assert.AreEqual(0, _race.DriversInOrder.Count);
        }

        [Test]
        public void Positions_ContainsAllSectionsFromTrack()
        {
            _race = new Race(_testTrack, _testParticipants);

            foreach (Section section in _testTrack.Sections)
            {
                Assert.IsTrue(_race.Positions.ContainsKey(section));
            }
        }

        [Test]
        public void Race_StartsWithCorrectNumberOfDrivers()
        {
            _race = new Race(_testTrack, new List<IParticipant>
            {
                new Driver { Name = "Driver1" },
                new Driver { Name = "Driver2" }
            });

            Assert.AreEqual(2, _race.Participants.Count);
        }

        [Test]
        public void Race_SetsCurrentRaceInData()
        {
            _race = new Race(_testTrack, _testParticipants);

            Assert.AreEqual(_race, Data.CurrentRace);
        }
    }
}

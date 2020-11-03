using Controller;
using Model;
using SuperCooleRace;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace RaceTrackMooi
{
    public class DataContext : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
                
        //Voor RaceStats
        public delegate string GetTrackName();
        public delegate List<Driver> GetDrivers();
        public string TrackName { get; set; }
        public List<Driver> Drivers { get; set; }

        //Voor DriverStats
        public List<string> Laptimes { get; set; }
        public List<string> Points { get; set; }
        public List<string> Podium { get; set; }



        public DataContext()
        {
            if (Data.CurrentRace != null)
            {
                Data.CurrentRace.Driverschanged += DataChanged;
            }

            //Voor RaceStats
            TrackName = $"Current track: {getTrackName()}";
            Drivers = getDrivers();

            //Voor DriverStats
            GetRaceResults();
        }

        //Zorgt ervoor dat de wpf wordt geupdate als de informatie verandert
        public void DataChanged(object sender, EventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(sender, new PropertyChangedEventArgs(""));
            }
        }

        public void GetRaceResults()
        {
            Laptimes = new List<string>();
            Points = new List<string>();
            Podium = new List<string>();

            foreach (Driver driver in getDrivers())
            {
                Laptimes.Add($"{driver.Name}: {driver.laptime.Time}");
                Points.Add($"{driver.Name}: {driver.Points}");
                Podium.Add($"{driver.Name}: {driver.Podium}");

            }
        }

        //Haalt naam van de track op
        GetTrackName getTrackName = () => Data.CurrentRace.Track.Name;

        //Haalt de driver op
        GetDrivers getDrivers = () => Data.CurrentRace.Participants;

    }
}

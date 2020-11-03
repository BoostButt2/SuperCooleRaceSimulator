using Controller;
using SuperCooleRace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RaceTrackMooi
{
    public class DataContext : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DataContext()
        {
            if (Data.CurrentRace != null)
            {
                Data.CurrentRace.Driverschanged += DataChanged;
            }
        }


        public void DataChanged(object sender, EventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(sender, new PropertyChangedEventArgs(""));
            }
        }

    }
}

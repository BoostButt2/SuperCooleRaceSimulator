using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using Controller;
using Model;
using RaceTrackMooi;
using System.Windows.Threading;
using System.Runtime.CompilerServices;

namespace RaceTrackMooi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Track properTrack;

        private RaceStats raceStats;
        private DriverStats driverStats;

        public MainWindow()
        {

            Data.Initialize();
            Data.NextRace();

            InitializeComponent();
            StartRace();

        }

        public void StartRace()
        {
            DriversChangedEventArgs driversChangedEventArgs = new DriversChangedEventArgs();
            driversChangedEventArgs.track = Data.CurrentRace.Track;

            AnEventHandler(this, driversChangedEventArgs);
            Data.CurrentRace.Driverschanged += AnEventHandler;

            LoadImage.ClearCache();
            Data.CurrentRace.NewRaceEvent += StartRace;
        }

        public void AnEventHandler(object sender, EventArgs e)
        {
                       this.EmptyImage.Dispatcher.BeginInvoke(
            DispatcherPriority.Send,
            new Action(() =>
            {
                this.EmptyImage.Source = null;
                this.EmptyImage.Source = VisualisationMooi.DrawTrack(Data.CurrentRace.Track);
            }));

        }

        private void MenuItem_RaceStats_Click(object sender, RoutedEventArgs e)
        {
            raceStats = new RaceStats();
            raceStats.Show();
        }

        private void MenuItem_DriverStats_Click(object sender, RoutedEventArgs e)
        {
            driverStats = new DriverStats();
            driverStats.Show();
        }

        private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

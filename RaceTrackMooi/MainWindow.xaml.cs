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

namespace RaceTrackMooi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SectionTypes[] properSections = { SectionTypes.StartGrid, SectionTypes.StartGrid, SectionTypes.RightCorner, SectionTypes.StraightVertical, SectionTypes.LeftCorner, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.SuperRightCorner, SectionTypes.StraightVertical, SectionTypes.SuperLeftCorner, SectionTypes.Finish };
            Track properTrack = new Track("Proper racetrack", properSections);

            Driver dimitri = new Driver("Dimitri");
            Driver totoro = new Driver("Totoro");
            Driver megumin = new Driver("Megumin");

            List<IParticipant> drivers = new List<IParticipant>();
            drivers.Add(dimitri);
            drivers.Add(totoro);
            drivers.Add(megumin);
            Race properRace = new Race(properTrack, drivers);
            //StartRace();

            this.StartGrid1.Dispatcher.BeginInvoke(
            DispatcherPriority.Render,
            new Action(() =>
            {
                this.StartGrid1.Source = null;
                this.StartGrid1.Source = VisualisationMooi.DrawTrack(properTrack);
            }));

        }

        public static void StartRace()
        {
            DriversChangedEventArgs driversChangedEventArgs = new DriversChangedEventArgs();
            driversChangedEventArgs.track = Data.CurrentRace.Track;

            Data.CurrentRace.Driverschanged += OnDriversChanged;
            Data.CurrentRace.NewRaceEvent += StartRace;


        }

        public static void OnDriversChanged(object sender, DriversChangedEventArgs e)
        {
            VisualisationMooi.DrawTrack(Data.CurrentRace.Track);
            Data.CurrentRace.Driverschanged += OnDriversChanged;
        }
    }
}

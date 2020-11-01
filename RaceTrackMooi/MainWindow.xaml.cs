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
        public MainWindow()
        {
            InitializeComponent();
            SectionTypes[] properSections = { SectionTypes.StartGrid, SectionTypes.StartGrid, SectionTypes.RightCorner, SectionTypes.StraightVertical, SectionTypes.LeftCorner, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.Straight, SectionTypes.SuperRightCorner, SectionTypes.StraightVertical, SectionTypes.SuperLeftCorner, SectionTypes.Finish };
            properTrack = new Track("Proper racetrack", properSections);

            Driver dimitri = new Driver("Dimitri");
            Driver totoro = new Driver("Totoro");
            Driver megumin = new Driver("Megumin");

            dimitri.TeamColor = TeamColors.Lime;
            totoro.TeamColor = TeamColors.Orange;
            megumin.TeamColor = TeamColors.Pink;


            List<IParticipant> drivers = new List<IParticipant>();
            drivers.Add(dimitri);
            drivers.Add(totoro);
            drivers.Add(megumin);
            Race properRace = new Race(properTrack, drivers);

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
                       this.StartGrid1.Dispatcher.BeginInvoke(
            DispatcherPriority.Send,
            new Action(() =>
            {
                this.StartGrid1.Source = null;
                this.StartGrid1.Source = VisualisationMooi.DrawTrack(Data.CurrentRace.Track);
            }));
        }
    }
}

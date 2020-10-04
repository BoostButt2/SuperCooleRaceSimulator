using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
   public class DriversChangedEventArgs : EventArgs
    {
        public Track track { get; set; }
    }
}

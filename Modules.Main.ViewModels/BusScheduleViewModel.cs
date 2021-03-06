﻿using Common.Base.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Main.ViewModels
{
    public class BusScheduleViewModel : BaseViewModel
    {
        public string StartingPoint { get; set; }
        public string Destination { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string TotalDuration { get; set; }

        //public BusStop StartBusStop { get; set; }
        //public BusStop EndBusStop { get; set; }

        //public ICollection<Bus> AllocatedBus { get; set; }

    }
}

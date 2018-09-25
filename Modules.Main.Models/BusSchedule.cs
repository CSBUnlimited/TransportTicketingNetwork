using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Main.Models
{
    public class BusSchedule
    {
        public int Id { get; set; }
        public string StartingPoint { get; set; }
        public string Destination { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string TotalDuration { get; set; }

        public BusStop StartBusStop { get; set; }
        public BusStop EndBusStop { get; set; }

        public ICollection<Bus>  AllocatedBus { get; set; }

    }
}

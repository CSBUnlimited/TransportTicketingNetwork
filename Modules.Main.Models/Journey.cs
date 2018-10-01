using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Main.Models
{
    public class Journey
    {
        public int Id { get; set; }
        public int StartBusStopId { get; set; }
        public BusStop StartBusStop { get; set; }

        public int EndBusStopId { get; set; }
        public BusStop EndBusStop { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        //public ICollection<SubRoute> SubRoutes { get; set; } Use a seperate class for 
        //public ICollection<BusStop> BusStops { get; set; }

       // public BusSchedule BusSchedule { get; set; }
        

        //public string _cardNumber{get; set;}
        //public float _accBalance{get; set;}

        

    }
}

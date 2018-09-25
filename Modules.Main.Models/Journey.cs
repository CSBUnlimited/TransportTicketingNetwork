using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Main.Models
{
    class Journey
    {
        public int _id { get; set; }
        public string startLocation { get; set; }
        public string endLocation { get; set; }
        public DateTime _startTime { get; set; }
        public DateTime _endTime { get; set; }

        public ICollection<SubRoute> subRoutes { get; set; }
        public ICollection<BusStop> _busStops { get; set; }

        public BusSchedule busSchedule { get; set; }
        

        //public string _cardNumber{get; set;}
        //public float _accBalance{get; set;}

        

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Main.Models
{
    public class Bus
    {
        public int Id { get; set; }

        public string BusName { get; set; }

        public string BusNumber{ get; set; }

        public string BusType { get; set; } 

        public int NoSeats { get; set; }

        public string Description { get; set; }

        //Assigning the Route when adding a Bus to the System - Sub RouteID/Object
        public string RouteId { get; set; }
        public Route Route { get; set; }


    }


}

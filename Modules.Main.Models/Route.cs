using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Main.Models
{
    public class Route
    {
        public int Id { get; set; }

        public int RootNumber { get; set; }

        public int Distance { get; set; }

        public string Description { get; set; }

        public string StartBusStopId { get; set; }

        public BusStop StartBusStop { get; set; }

        
        

        
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Main.Models
{
    public class Route
    {
        public string Id { get; set; }
        public int Distance { get; set; }

        public BusStop StartBusStop { get; set; }
        public string StartBusStopId { get; set; }
    }
}

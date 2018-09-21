using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Main.Models
{
   public class SubRoute
    {
        public string Id { get; set; }

        public string RouteId { get; set; }

        public string EndBusStopId { get; set; }

        public int Distance { get; set; }

        public int Fare { get; set; }
    }
}

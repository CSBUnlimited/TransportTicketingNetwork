using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Main.Models
{
    class SubRoute
    {
        public String SubRouteId { get; set; }

        public String RouteId { get; set; }

        public String EndBusStopId { get; set; }

        public int Distance { get; set; }

        public int Fare { get; set; }
    }
}

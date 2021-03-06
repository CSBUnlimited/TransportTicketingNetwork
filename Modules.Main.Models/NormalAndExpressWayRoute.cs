﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Main.Models
{
    public class NormalAndExpressWayRoute: Route
    {
        public IEnumerable<BusStop> BusStopIdList { get; set; }

        public IEnumerable<float> DistanceList { get; set; }

        public IEnumerable<int> ExpressFareList { get; set; }
    }
}

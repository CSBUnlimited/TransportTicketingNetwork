﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Main.Models
{
    public class ExpressWayRoute: Route
    {
        public BusStop StartLocation { get; set; }

        public BusStop EndLocation { get; set; }

        public double Distance { get; set; }

        public int Fare { get; set; }

    }
}

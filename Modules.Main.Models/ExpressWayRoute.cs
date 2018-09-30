using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Main.Models
{
    public class ExpressWayRoute: Route
    {
        public string StartLocation { get; set; }

        public string EndLocation { get; set; }

        public float Distance { get; set; }

    }
}

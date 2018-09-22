using System.Collections.Generic;

namespace Modules.Main.Models
{
    public class BusStop
    {
        public string Id { get; set; }
        public string BusStopName { get; set; }

        public IEnumerable<Route> Routes { get; set; }

        public BusStop()
        {
            Routes = new HashSet<Route>();
        }
    }
}

using Common.Base.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Main.ViewModels
{
    public class RouteViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public int Distance { get; set; }

        public int RouteNumber { get; set; }

        public string Description { get; set; }

        public string StartBusStopId { get; set; }
    }
}

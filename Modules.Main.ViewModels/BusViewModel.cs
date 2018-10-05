using Common.Base.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Main.ViewModels
{
    public class BusViewModel : BaseViewModel
    {
        public string BusName { get; set; }

        public string BusNumber { get; set; }

        public string BusType { get; set; }

        public int NoSeats { get; set; }

        public string Description { get; set; }

        //Assigning the Route when adding a Bus to the System - Sub RouteID
        public string RouteId { get; set; }
    }
}

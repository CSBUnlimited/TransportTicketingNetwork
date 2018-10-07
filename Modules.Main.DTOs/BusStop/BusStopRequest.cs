using Common.Base.DTOs;
using Modules.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Main.DTOs.BusStop
{
    public class BusStopRequest :BaseRequest
    {
        public BusStopViewModel BusStopViewModel { get; set; }
    }
}

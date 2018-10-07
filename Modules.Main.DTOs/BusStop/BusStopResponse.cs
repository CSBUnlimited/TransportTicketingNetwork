using Common.Base.DTOs;
using Modules.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Main.DTOs.BusStop
{
   public class BusStopResponse : BaseResponse
    {
        public IEnumerable<BusStopViewModel> BusStopViewModels { get; set; }
    }
}

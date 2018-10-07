using Common.Base.DTOs;
using Modules.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Main.DTOs.BusSchedule
{
    public class BusScheduleResponse : BaseResponse
    {
        public IEnumerable<BusScheduleViewModel> BusScheduleViewModels { get; set; }
    }
}

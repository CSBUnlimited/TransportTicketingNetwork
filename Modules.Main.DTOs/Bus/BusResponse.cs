using Common.Base.DTOs;
using Modules.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Main.DTOs.Bus
{
    public class BusResponse : BaseResponse
    {
        public IEnumerable<BusViewModel> BusViewModels{ get; set; }

    }
}

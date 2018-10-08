using Common.Base.DTOs;
using Modules.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Main.DTOs.Bus
{
    public class BusResponse : BaseResponse
    {
        //Changes   public BusViewModel BusViewModel { get; set; } Added To Get Bus By ID
        public BusViewModel BusViewModel { get; set; }
        public IEnumerable<BusViewModel> BusViewModels{ get; set; }

    }
}

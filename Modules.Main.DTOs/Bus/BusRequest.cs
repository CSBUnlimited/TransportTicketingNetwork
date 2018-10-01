using Common.Base.DTOs;
using Modules.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Main.DTOs.Bus
{
    public class BusRequest : BaseRequest
    {
        public BusViewModel BusViewModel { get; set; }
    }
}

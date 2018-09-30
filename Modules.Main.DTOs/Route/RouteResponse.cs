using Common.Base.DTOs;
using Modules.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Main.DTOs.Route
{
    public class RouteResponse : BaseResponse
    {
        public IEnumerable<RouteViewModel> RouteViewModels { get; set; }
    }
}

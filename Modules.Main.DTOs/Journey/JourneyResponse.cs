using Common.Base.DTOs;
using Modules.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Main.DTOs.Journey
{
    public class JourneyResponse : BaseResponse
    {
        public IEnumerable<JourneyViewModel> JourneyViewModels { get; set; }
    }
}

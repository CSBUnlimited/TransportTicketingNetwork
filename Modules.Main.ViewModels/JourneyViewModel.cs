using Common.Base.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Main.ViewModels
{
    public class JourneyViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public int StartBusStopId { get; set; }
       
        public int EndBusStopId { get; set; }
        
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}

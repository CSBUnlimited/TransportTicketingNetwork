using Modules.Main.Core.Services;
using Modules.Main.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Main.Services
{
    public class BusStopService : IBusStopService
    {
        private IBusStopService _busStopServices;

        public BusStopService(IBusStopService busStopServices) {

            _busStopServices = busStopServices;
        }
        //Overide The AddBusStop Method
        public BusStop AddBusStop(BusStop busstops) {
            throw new System.NotImplementedException();
        }
    }
}

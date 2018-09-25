using Modules.Main.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.Main.Core.Services
{
    public interface IBusStopService
    {
        //Method For Adding a BusStop
        BusStop AddBusStop(BusStop busstops);
    }
}

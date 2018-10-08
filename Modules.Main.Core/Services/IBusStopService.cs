using Common.Core.Services;
using Modules.Main.Models;
using Modules.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Main.Core.Services
{
    public interface IBusStopService: IService
    {
        //Method For Adding a BusStop
        Task<BusStopViewModel> AddBusStop(BusStopViewModel busstops);

        Task<IEnumerable<BusStopViewModel>> GetBusStopListAsync();


    }
}

using Common.Core.Services;
using Modules.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Main.Core.Services
{
    public interface IBusScheduleService : IService
    {
        //Getting all the Bus Schedules
        Task<IEnumerable<BusScheduleViewModel>> GetBusScheduleListAsync();

    }
}

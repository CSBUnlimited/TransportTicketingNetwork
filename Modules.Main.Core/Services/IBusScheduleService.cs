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

        //Adding a Bus
        Task<BusScheduleViewModel> AddBusScheduleAsync (BusScheduleViewModel busSchedules); 

        //Deleting a Bus
        Task<BusScheduleViewModel> DeleteBusScheduleAsync(int id);

        //Updating a Bus
        Task<BusScheduleViewModel> UpdateBusScheduleAsync(int id, BusScheduleViewModel updatedBusSchedule);

        //Searching By Keyword
    }
}

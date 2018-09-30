using Common.Core.Services;
using Modules.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Main.Core.Services
{
    public interface IBusService: IService 
    {
        //Getting all the Buses
        Task<IEnumerable<BusViewModel>> GetBusListAsync();

        //Adding a Bus
        Task<BusViewModel> AddBusAsync(BusViewModel buses);
    }

}

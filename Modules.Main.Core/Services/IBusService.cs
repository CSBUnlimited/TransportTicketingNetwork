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

        //Get Bus By Bus Number
        Task<BusViewModel> GetBusAsync(string busNumber);

        //Getting all the Buses
        Task<IEnumerable<BusViewModel>> GetBusListAsync();

        //Adding a Bus
        Task<BusViewModel> AddBusAsync(BusViewModel buses);

        //Deleting a Bus
        Task<BusViewModel> DeleteBus(string busNumber); 
    }

}

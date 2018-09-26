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
        Task<IEnumerable<BusViewModel>> GetBusListAsync();
    }

}

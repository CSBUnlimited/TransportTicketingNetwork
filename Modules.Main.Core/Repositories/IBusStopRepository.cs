using Common.Core.Repositories;
using Modules.Main.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Main.Core.Repositories
{
    public interface IBusStopRepository : IRepository
    {
        Task AddBusStops(BusStop busstop);

        Task<IEnumerable<BusStop>> GetBusStopList();
    }
}

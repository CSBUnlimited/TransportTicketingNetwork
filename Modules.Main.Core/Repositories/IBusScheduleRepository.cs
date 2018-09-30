using Common.Core.Repositories;
using Modules.Main.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Main.Core.Repositories
{
    public interface IBusScheduleRepository : IRepository
    {
        /// <summary>
        /// Get Bus Schedule List
        /// </summary>
        /// <returns>Bus Schedule List or null, if not found</returns>

        Task<IEnumerable<BusSchedule>> GetBusScheduleList();

    }
}

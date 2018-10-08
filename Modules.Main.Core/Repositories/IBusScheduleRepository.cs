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
        /// Get Bus Schedule 
        /// </summary>
        /// <returns>Bus or null, if not found</returns>
        Task<BusSchedule> GetBusSchedule(int id);

        /// <summary>
        /// Get Bus Schedule ByStartingPoint
        /// </summary>
        /// <returns>Bus or null, if not found</returns>
        Task<BusSchedule> GetBusScheduleByStartingPoint(string staringPoint);

        /// <summary>
        /// Get Bus Schedule List
        /// </summary>
        /// <returns>Bus Schedule List or null, if not found</returns>

        Task<IEnumerable<BusSchedule>> GetBusScheduleList();

        /// <summary>
        /// Add Bus Schedule
        /// </summary>
        /// <returns></returns>
        Task AddBusSchedule(BusSchedule busSchedule);

        /// <summary>
        /// Delete Bus Schedule
        /// </summary>
        /// <returns></returns>
        void DeleteBusSchedule(BusSchedule busSchedule);

        /// <summary>
        /// Update Bus Schedule
        /// </summary>
        /// <returns></returns>
        void UpdateBusSchedule(BusSchedule busSchedule);

    }
}

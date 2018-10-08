using Common.Core.Repositories;
using Modules.Main.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Main.Core.Repositories
{
    public interface IBusRepository : IRepository
    {

        /// <summary>
        /// Get Bus 
        /// </summary>
        /// <returns>Bus or null, if not found</returns>
        Task<Bus> GetBus(string busNumber);
        
        /// <summary>
        /// Get Bus List
        /// </summary>
        /// <returns>Bus List or null, if not found</returns>

        Task<IEnumerable<Bus>> GetBusList();

        /// <summary>
        /// Add Bus
        /// </summary>
        /// <returns></returns>
        Task AddBus(Bus bus);

        /// <summary>
        /// Delete Bus
        /// </summary>
        /// <returns></returns>
        void DeleteBus(Bus bus);

        /// <summary>
        /// Update Bus
        /// </summary>
        /// <returns></returns>
        void UpdateBus(Bus bus);





    }
}

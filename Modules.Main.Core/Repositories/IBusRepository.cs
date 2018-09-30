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
        /// Get Bus List
        /// </summary>
        /// <returns>Bus List or null, if not found</returns>
        Task<IEnumerable<Bus>> GetBusList();


    }
}

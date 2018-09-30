using Common.Core.Repositories;
using Modules.Main.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Main.Core.Repositories
{
    public interface IRouteRepository : IRepository
    {
        Task AddRoutes(Route route);

        Task<IEnumerable<Route>> GetRouteList();

    }

}

using Common.Base.Repositories;
using Modules.Main.Core.Repositories;
using Modules.Main.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TransportTicketingNetwork.Database;

namespace Modules.Main.Repositories
{
    public class RouteRepository : BaseRepository , IRouteRepository
    {
        private TransportTicketingNetworkDbContext _dbContext;
        public RouteRepository(TransportTicketingNetworkDbContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;


        }
        
        public async Task AddRoutes(Route route)
        {
           await _dbContext.AddAsync(route);
        }
    }
}

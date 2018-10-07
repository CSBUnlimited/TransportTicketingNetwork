using Common.Base.Repositories;
using Microsoft.EntityFrameworkCore;
using Modules.Main.Core.Repositories;
using Modules.Main.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TransportTicketingNetwork.Database;

namespace Modules.Main.Repositories
{
    public class BusStopRepository : BaseRepository, IBusStopRepository
    {
        private TransportTicketingNetworkDbContext _dbContext;
        public BusStopRepository(TransportTicketingNetworkDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;


        }
        public async Task AddBusStops(BusStop busstop)
        {
            await _dbContext.AddAsync(busstop);
        }

        public async Task<IEnumerable<BusStop>> GetBusStopList()
        {
            return await _dbContext.BusStops.ToListAsync();
        }
    }
}

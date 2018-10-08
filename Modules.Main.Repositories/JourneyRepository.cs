using System;
using System.Collections.Generic;
using System.Text;
using Modules.Main.Core.Repositories;
using TransportTicketingNetwork.Database;
using Common.Base.Repositories;
using Modules.Main.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Modules.Main.Repositories
{
    public class JourneyRepository : BaseRepository, IJourneyRepository
    {
        private TransportTicketingNetworkDbContext _dbContext;
        public JourneyRepository(TransportTicketingNetworkDbContext dbContext) : base(dbContext)
        {
            _dbContext= dbContext;

        }

        public async Task AddJourneys(Journey journey)
        {
            await _dbContext.Journeys.AddAsync(journey);
        }
        public async Task<IEnumerable<Journey>> GetJourneyList()
        {
            return await _dbContext.Journeys.ToListAsync();
        }
    }
}

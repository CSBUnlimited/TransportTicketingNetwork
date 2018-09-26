using System;
using System.Collections.Generic;
using System.Text;
using Modules.Main.Core.Repositories;
using TransportTicketingNetwork.Database;
using Common.Base.Repositories;

namespace Modules.Main.Repositories
{
    public class JourneyRepository : BaseRepository, IJourneyRepository
    {
        protected new TransportTicketingNetworkDbContext DbContext { get; }
        public JourneyRepository(TransportTicketingNetworkDbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;

        }
    }
}

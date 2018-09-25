using Common.Base.Repositories;
using Microsoft.EntityFrameworkCore;
using Modules.Main.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using TransportTicketingNetwork.Database;

namespace Modules.Main.Repositories
{
    public class BusRepository : BaseRepository, IBusRepository
    {
        protected new TransportTicketingNetworkDbContext DbContext { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">TransportTicketingNetworkDbContext</param>
        public BusRepository(TransportTicketingNetworkDbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
    
        }

    }
}

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
    public class BusScheduleRepository : BaseRepository, IBusScheduleRepository
    {
        protected new TransportTicketingNetworkDbContext DbContext { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">TransportTicketingNetworkDbContext</param>
        /// 

        public BusScheduleRepository(TransportTicketingNetworkDbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<IEnumerable<BusSchedule>> GetBusScheduleList()
        {
            return await DbContext.BusSchedules.ToListAsync();
        }


    }
}

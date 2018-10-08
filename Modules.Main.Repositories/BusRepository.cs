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

        public async Task<Bus> GetBus(string busNumber)
        {
            return await DbContext.Buses.FindAsync(busNumber);
        }
        public async Task<IEnumerable<Bus>> GetBusList()
        {
            return await DbContext.Buses.ToListAsync();
        }

        public async Task AddBus(Bus bus)
        {
            await DbContext.Buses.AddAsync(bus);
        }

       
        public void DeleteBus(Bus bus)
        {
            DbContext.Buses.Remove(bus);
        }

        //Update
        public void UpdateBus(Bus bus)
        {
            DbContext.Buses.Update(bus);
        }

        //Search
        //public async Task<IEnumerable<Bus>> SearchBus(string keyword)
        //{
        //    await DbContext.Buses.ContainsAsync(keyword);
        //}


    }
}

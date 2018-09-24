using Common.Base.Repositories;
using Modules.Main.Core.Repositories;
using Modules.Main.Models;
using TransportTicketingNetwork.Database;

namespace Modules.Main.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        protected new TransportTicketingNetworkDbContext DbContext { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">TransportTicketingNetworkDbContext</param>
        public UserRepository(TransportTicketingNetworkDbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
        }
    }
}

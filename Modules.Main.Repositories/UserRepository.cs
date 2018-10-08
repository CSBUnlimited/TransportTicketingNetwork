using System.Threading.Tasks;
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

        /// <summary>
        /// Add UserExt - Async
        /// </summary>
        /// <param name="user">User</param>
        /// <returns></returns>
        public async Task AddUserExtAsync(UserExt user)
        {
            await DbContext.UserExts.AddAsync(user);
        }
    }
}

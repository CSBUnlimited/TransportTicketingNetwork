using System.Threading.Tasks;
using Common.Base.Repositories;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using TransportTicketingNetwork.Database;
using Utilities.Authorization.Core.Repositories;

namespace Utilities.Authorization.Repositories
{
    public sealed class UserRepository : BaseRepository, IUserRepository
    {
        private new TransportTicketingNetworkDbContext DbContext { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">Transport Ticketing Network Db Context</param>
        public UserRepository(TransportTicketingNetworkDbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
        }

        /// <summary>
        /// Get User By Id - Async
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>User</returns>
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await DbContext.Users.FindAsync(id);
        }

        /// <summary>
        /// Get User By Username - Async
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>User</returns>
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await DbContext.Users.SingleOrDefaultAsync(u => u.ApplicationUser.Username == username);
        }
    }
}

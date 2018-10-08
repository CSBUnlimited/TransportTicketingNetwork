using System.Threading.Tasks;
using Common.Base.Repositories;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using Modules.Main.Core.Repositories;
using TransportTicketingNetwork.Database;

namespace Modules.Main.Repositories
{
    public class UserRoleRepository : BaseRepository, IUserRoleRepository
    {
        protected new TransportTicketingNetworkDbContext DbContext { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">TransportTicketingNetworkDbContext</param>
        public UserRoleRepository(TransportTicketingNetworkDbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
        }

        /// <summary>
        /// Get User Role By Description - Async
        /// </summary>
        /// <param name="userRoleDescription">User Role Description</param>
        /// <returns>UserRole</returns>
        public async Task<UserRole> GetUserRoleByDescriptionAsync(string userRoleDescription)
        {
            return await DbContext.UserRoles.FirstOrDefaultAsync(ur => ur.Description == userRoleDescription);
        }
    }
}

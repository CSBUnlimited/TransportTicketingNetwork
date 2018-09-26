using System;
using System.Threading.Tasks;
using Common.Base.Repositories;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using TransportTicketingNetwork.Database;
using Utilities.Authorization.Core.Repositories;

namespace Utilities.Authorization.Repositories
{
    public class AuthorizationRepository : BaseRepository, IAuthorizationRepository
    {
        protected new TransportTicketingNetworkDbContext DbContext { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">Transport Ticketing Network Db Context</param>
        public AuthorizationRepository(TransportTicketingNetworkDbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
        }

        /// <summary>
        /// Get Application User By Username And ExpireDate - Async.
        /// Username need match and user cannot be expired
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>ApplicationUser, null if not found</returns>
        public async Task<ApplicationUser> GetApplicationUserByUsernameAndExpireDateAsync(string username)
        {
            return await DbContext.ApplicationUsers
                .Include(au => au.User)
                .SingleOrDefaultAsync(au => au.Username == username && au.EffectiveDateTime <= DateTime.UtcNow && au.ExpireDateTime > DateTime.UtcNow);
        }

        /// <summary>
        /// Get Application User By Username - Async.
        /// Username need match and expire dates are not checking.
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>ApplicationUser, null if not found</returns>
        public async Task<ApplicationUser> GetApplicationUserByUsernameAsync(string username)
        {
            return await DbContext.ApplicationUsers.SingleOrDefaultAsync(au => au.Username == username);
        }

        /// <summary>
        /// Add Application User Token - Async
        /// </summary>
        /// <param name="applicationUserToken">ApplicationUserToken</param>
        /// <returns></returns>
        public async Task AddApplicationUserTokenAsync(ApplicationUserToken applicationUserToken)
        {
            await DbContext.ApplicationUserTokens.AddAsync(applicationUserToken);
        }
    }
}

using System;
using System.Threading.Tasks;
using Common.Base.Repositories;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using TransportTicketingNetwork.Database;
using Utilities.Authorization.Core.Repositories;

namespace Utilities.Authorization.Repositories
{
    public sealed class ApplicationUserRepository : BaseRepository, IApplicationUserRepository
    {
        private new TransportTicketingNetworkDbContext DbContext { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">Transport Ticketing Network Db Context</param>
        public ApplicationUserRepository(TransportTicketingNetworkDbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
        }

        /// <summary>
        /// Get Application User Which Not Expired By Username - Async.
        /// Username need match and user cannot be expired.
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>ApplicationUser, null if not found</returns>
        public async Task<ApplicationUser> GetApplicationUserWhichNotExpiredByUsernameAsync(string username)
        {
            return await DbContext.ApplicationUsers
                .SingleOrDefaultAsync(au => au.Username == username && au.EffectiveDateTime <= DateTime.UtcNow && au.ExpireDateTime > DateTime.UtcNow);
        }

        /// <summary>
        /// Get Application User Including User Which Not Expired By Username - Async.
        /// Username need match and user cannot be block or expired.
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>ApplicationUser, null if not found</returns>
        public async Task<ApplicationUser> GetApplicationUserIncludingUserWhichNotBlockedAndExpiredByUsernameAsync(string username)
        {
            return await DbContext.ApplicationUsers
                .Include(au => au.User)
                .SingleOrDefaultAsync(au => au.Username == username &&
                                            !au.IsBlocked &&
                                            au.EffectiveDateTime <= DateTime.UtcNow &&
                                            au.ExpireDateTime > DateTime.UtcNow);
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
        /// Is Application User Available Which Not Expired By Username - Async.
        /// This will check whether user is expired.
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>True if found</returns>
        public async Task<bool> IsApplicationUserAvailableWhichNotExpiredByUsernameAsync(string username)
        {
            return await DbContext.ApplicationUsers.AnyAsync(au => au.Username == username &&
                                                                   au.EffectiveDateTime <= DateTime.UtcNow &&
                                                                   au.ExpireDateTime > DateTime.UtcNow);
        }

        /// <summary>
        /// Is Application User Available - Async
        /// This will check whether user is expired and is blocked.
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>True if found</returns>
        public async Task<bool> IsApplicationUserAvailableWhichNotBlockedAndExpiredByUsernameAsync(string username)
        {
            return await DbContext.ApplicationUsers.AnyAsync(au => au.Username == username && 
                                                                   !au.IsBlocked && 
                                                                   au.EffectiveDateTime <= DateTime.UtcNow && 
                                                                   au.ExpireDateTime > DateTime.UtcNow);
        }
    }
}

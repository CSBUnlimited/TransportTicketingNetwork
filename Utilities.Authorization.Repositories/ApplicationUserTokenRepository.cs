using System;
using System.Threading.Tasks;
using Common.Base.Repositories;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using TransportTicketingNetwork.Database;
using Utilities.Authorization.Core.Repositories;

namespace Utilities.Authorization.Repositories
{
    public sealed class ApplicationUserTokenRepository : BaseRepository, IApplicationUserTokenRepository
    {
        private new TransportTicketingNetworkDbContext DbContext { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">Transport Ticketing Network Db Context</param>
        public ApplicationUserTokenRepository(TransportTicketingNetworkDbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
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

        /// <summary>
        /// Get Application User Token Which Not Expired By Session Hash - Async.
        /// Check whether user is expired.
        /// </summary>
        /// <param name="sessionHash">Session Hash</param>
        /// <returns>ApplicationUserToken, null if not found</returns>
        public async Task<ApplicationUserToken> GetApplicationUserTokenWhichNotExpiredBySessionHashAsync(string sessionHash)
        {
            return await DbContext.ApplicationUserTokens
                .SingleOrDefaultAsync(aut => aut.SessionHash == sessionHash && aut.EffectiveDateTime <= DateTime.UtcNow && aut.ExpireDateTime > DateTime.UtcNow);
        }
    }
}

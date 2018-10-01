using System.Threading.Tasks;
using Common.Core.Repositories;
using Common.Models;

namespace Utilities.Authorization.Core.Repositories
{
    public interface IApplicationUserTokenRepository : IRepository
    {
        /// <summary>
        /// Add Application User Token - Async
        /// </summary>
        /// <param name="applicationUserToken">ApplicationUserToken</param>
        /// <returns></returns>
        Task AddApplicationUserTokenAsync(ApplicationUserToken applicationUserToken);

        /// <summary>
        /// Get Application User Token Which Not Expired By Session Hash - Async.
        /// Check whether user is expired.
        /// </summary>
        /// <param name="sessionHash">Session Hash</param>
        /// <returns>ApplicationUserToken, null if not found</returns>
        Task<ApplicationUserToken> GetApplicationUserTokenWhichNotExpiredBySessionHashAsync(string sessionHash);
    }
}

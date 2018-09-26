using System.Threading.Tasks;
using Common.Core.Repositories;
using Common.Models;

namespace Utilities.Authorization.Core.Repositories
{
    public interface IAuthorizationRepository : IRepository
    {
        /// <summary>
        /// Get Application User By Username - Async.
        /// Username need match and expire dates are not checking.
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>ApplicationUser, null if not found</returns>
        Task<ApplicationUser> GetApplicationUserByUsernameAsync(string username);

        /// <summary>
        /// Get Application User By Username And ExpireDate - Async.
        /// Username need match and user cannot be expired
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>ApplicationUser, null if not found</returns>
        Task<ApplicationUser> GetApplicationUserByUsernameAndExpireDateAsync(string username);

        /// <summary>
        /// Add Application User Token - Async
        /// </summary>
        /// <param name="applicationUserToken">ApplicationUserToken</param>
        /// <returns></returns>
        Task AddApplicationUserTokenAsync(ApplicationUserToken applicationUserToken);
    }
}

using System.Threading.Tasks;
using Common.Core.Repositories;
using Common.Models;

namespace Utilities.Authorization.Core.Repositories
{
    public interface IApplicationUserRepository : IRepository
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
        Task<ApplicationUser> GetApplicationUserWhichNotExpiredByUsernameAsync(string username);

        /// <summary>
        /// Get Application User Including User Which Not Expired By Username - Async.
        /// Username need match and user cannot be block or expired.
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>ApplicationUser, null if not found</returns>
        Task<ApplicationUser> GetApplicationUserIncludingUserWhichNotBlockedAndExpiredByUsernameAsync(string username);

        /// <summary>
        /// Is Application User Available Which Not Expired By Username - Async.
        /// This will check whether user is expired.
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>True if found</returns>
        Task<bool> IsApplicationUserAvailableWhichNotExpiredByUsernameAsync(string username);


        /// <summary>
        /// Is Application User Available Which Not Blocked And Expired By Username - Async
        /// This will check whether user is expired and is blocked.
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>True if found</returns>
        Task<bool> IsApplicationUserAvailableWhichNotBlockedAndExpiredByUsernameAsync(string username);
    }
}

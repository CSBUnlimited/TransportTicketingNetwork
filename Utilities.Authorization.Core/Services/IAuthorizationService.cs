using System.Threading.Tasks;
using Common.Core.Services;

namespace Utilities.Authorization.Core.Services
{
    public interface IAuthorizationService : IService
    {
        /// <summary>
        /// Is User Authorized - Async.
        /// Check whether user is available.
        /// Check whether sessionHash is valid.
        /// TODO: Check user have the permission to execute that controller or not.
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="sessionHash">Session Hash</param>
        /// <returns>Whether authorized or not</returns>
        Task<bool> IsUserAuthorizedAsync(string username, string sessionHash);

        /// <summary>
        /// Authenticate User Login - Async.
        /// Check user is available.
        /// Check user is blocked.
        /// Check user given password is correct.
        /// Create token to the user
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Encoded Password</param>
        /// <returns>Authentication Token</returns>
        Task<string> AuthenticateLoginAsync(string username, string password);

        /// <summary>
        /// Regenerate new token and expire the current token - Async.
        /// Check validity of current session hash
        /// </summary>
        /// <returns></returns>
        Task<string> RenewAuthenticateTokenAndExpireOldTokenAsync();

        /// <summary>
        /// Logout User - Async
        /// </summary>
        /// <returns></returns>
        Task LogoutUserAsync();
    }
}

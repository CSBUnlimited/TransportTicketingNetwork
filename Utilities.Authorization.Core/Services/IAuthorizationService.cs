using System.Threading.Tasks;
using Common.Core.Services;

namespace Utilities.Authorization.Core.Services
{
    public interface IAuthorizationService : IService
    {
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
    }
}

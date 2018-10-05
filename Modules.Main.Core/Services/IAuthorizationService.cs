using System.Threading.Tasks;
using Common.Core.Services;
using Modules.Main.ViewModels;

namespace Modules.Main.Core.Services
{
    public interface IAuthorizationService : IService
    {
        /// <summary>
        /// Check user given data is valid or not
        /// </summary>
        /// <param name="loginViewModel">LoginViewModel</param>
        /// <returns>Authentication Token</returns>
        Task<string> UserLoginAsync(LoginViewModel loginViewModel);

        /// <summary>
        /// Renew Authentication Token - Async
        /// </summary>
        /// <returns>New Token</returns>
        Task<string> RenewAuthenticationTokenAsync();

        /// <summary>
        /// User logout - Async
        /// </summary>
        /// <returns></returns>
        Task UserLogoutAsync();
    }
}

using System.Threading.Tasks;
using Common.Base.Services;
using Modules.Main.Core.Services;
using Modules.Main.ViewModels;
using UtilAuth = Utilities.Authorization.Core.Services;

namespace Modules.Main.Services
{
    public class AuthorizationService : BaseService, IAuthorizationService
    {
        private readonly UtilAuth.IAuthorizationService _authorizationService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="authorizationService">Authorization Service</param>
        public AuthorizationService(UtilAuth.IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        /// <summary>
        /// Check user given data is valid or not - Async
        /// </summary>
        /// <param name="loginViewModel">LoginViewModel</param>
        /// <returns>Authentication Token</returns>
        public async Task<string> UserLoginAsync(LoginViewModel loginViewModel)
        {
            return await _authorizationService.AuthenticateLoginAsync(loginViewModel.Username, loginViewModel.Password);
        }

        /// <summary>
        /// Renew Authentication Token - Async
        /// </summary>
        /// <returns>New Token</returns>
        public async Task<string> RenewAuthenticationTokenAsync()
        {
            return await _authorizationService.RenewAuthenticateTokenAndExpireOldTokenAsync();
        }

        /// <summary>
        /// User logout - Async
        /// </summary>
        /// <returns></returns>
        public async Task UserLogoutAsync()
        {
            await _authorizationService.LogoutUserAsync();
        }
    }
}

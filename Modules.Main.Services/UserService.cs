using System.Threading.Tasks;
using Common.Base.Services;
using Modules.Main.Core.DataAccess;
using Modules.Main.Core.Services;
using Modules.Main.ViewModels;
using Utilities.Authorization.Core.Services;

namespace Modules.Main.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IMainUnitOfWork _mainUnitOfWork;
        private readonly IAuthorizationService _authorizationService;

        public UserService(IMainUnitOfWork mainUnitOfWork, IAuthorizationService authorizationService)
        {
            _mainUnitOfWork = mainUnitOfWork;
            _authorizationService = authorizationService;
        }

        /// <summary>
        /// Check user given data is valid or not
        /// </summary>
        /// <param name="loginViewModel">LoginViewModel</param>
        /// <returns>Authentication Token</returns>
        public async Task<string> UserLoginAsync(LoginViewModel loginViewModel)
        {
            return await _authorizationService.AuthenticateLoginAsync(loginViewModel.Username, loginViewModel.Password);
        }
    }
}

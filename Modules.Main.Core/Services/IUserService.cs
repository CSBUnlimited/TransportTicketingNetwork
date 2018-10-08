using System.Threading.Tasks;
using Common.Core.Services;
using Modules.Main.ViewModels;

namespace Modules.Main.Core.Services
{
    public interface IUserService : IService
    {
        /// <summary>
        /// Register User - Async
        /// </summary>
        /// <param name="userExtViewModel">User View Model Ext</param>
        /// <returns>User View Model</returns>
        Task<UserViewModel> RegisterUserAsync(UserExtViewModel userExtViewModel);
    }
}

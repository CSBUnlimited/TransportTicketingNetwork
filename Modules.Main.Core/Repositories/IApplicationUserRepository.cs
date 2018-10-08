using System.Threading.Tasks;
using Common.Core.Repositories;
using Common.Models;

namespace Modules.Main.Core.Repositories
{
    public interface IApplicationUserRepository : IRepository
    {
        /// <summary>
        /// Get Application User by Username witch is not expired - Async
        /// </summary>
        /// <param name="username">Username needed</param>
        /// <returns>Application User or null, if not found</returns>
        Task<ApplicationUser> GetApplicationUserByUserNameAsync(string username);


    }
}

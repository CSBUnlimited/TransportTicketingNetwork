using System.Threading.Tasks;
using Common.Core.Repositories;
using Common.Models;

namespace Modules.Main.Core.Repositories
{
    public interface IUserRoleRepository : IRepository
    {
        /// <summary>
        /// Get User Role By Description - Async
        /// </summary>
        /// <param name="userRoleDescription">User Role Description</param>
        /// <returns>UserRole</returns>
        Task<UserRole> GetUserRoleByDescriptionAsync(string userRoleDescription);
    }
}

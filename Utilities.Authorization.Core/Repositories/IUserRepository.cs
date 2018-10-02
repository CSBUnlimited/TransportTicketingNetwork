using System.Threading.Tasks;
using Common.Core.Repositories;
using Common.Models;

namespace Utilities.Authorization.Core.Repositories
{
    public interface IUserRepository : IRepository
    {
        /// <summary>
        /// Get User By Id - Async
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>User</returns>
        Task<User> GetUserByIdAsync(int id);

        /// <summary>
        /// Get User By Username - Async
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>User</returns>
        Task<User> GetUserByUsernameAsync(string username);
    }
}

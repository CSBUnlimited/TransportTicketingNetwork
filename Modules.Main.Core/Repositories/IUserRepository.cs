using System.Threading.Tasks;
using Common.Core.Repositories;
using Modules.Main.Models;

namespace Modules.Main.Core.Repositories
{
    public interface IUserRepository : IRepository
    {
        /// <summary>
        /// Add User - Async
        /// </summary>
        /// <param name="user">User</param>
        /// <returns></returns>
        Task AddUserExtAsync(UserExt user);
    }
}

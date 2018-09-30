using Common.Core.DataAccess;
using Utilities.Authorization.Core.Repositories;

namespace Utilities.Authorization.Core.DataAccess
{
    public interface IAuthorizationUnitOfWork : IUnitOfWork
    {
        IUserRepository UserRepository{ get; }
        IApplicationUserRepository ApplicationUserRepository{ get; }
        IApplicationUserTokenRepository ApplicationUserTokenRepository { get; }
    }
}

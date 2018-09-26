using Common.Core.DataAccess;
using Utilities.Authorization.Core.Repositories;

namespace Utilities.Authorization.Core.DataAccess
{
    public interface IAuthorizationUnitOfWork : IUnitOfWork
    {
        IAuthorizationRepository AuthorizationRepository { get; }
    }
}

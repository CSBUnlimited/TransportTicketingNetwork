using Common.Base.DataAccess;
using TransportTicketingNetwork.Database;
using Utilities.Authorization.Core.DataAccess;
using Utilities.Authorization.Core.Repositories;

namespace Utilities.Authorization.DataAccess
{
    public sealed class AuthorizationUnitOfWork : UnitOfWork, IAuthorizationUnitOfWork
    {
        #region Repositories

        public IAuthorizationRepository AuthorizationRepository { get; }

        #endregion

        public AuthorizationUnitOfWork
        (
            TransportTicketingNetworkDbContext dbContext,
            IAuthorizationRepository authorizationRepository
        ) : base(dbContext)
        {
            AuthorizationRepository = authorizationRepository;
        }
    }
}

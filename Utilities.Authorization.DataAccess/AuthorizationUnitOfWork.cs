using Common.Base.DataAccess;
using TransportTicketingNetwork.Database;
using Utilities.Authorization.Core.DataAccess;
using Utilities.Authorization.Core.Repositories;

namespace Utilities.Authorization.DataAccess
{
    public sealed class AuthorizationUnitOfWork : UnitOfWork, IAuthorizationUnitOfWork
    {
        #region Repositories

        public IUserRepository UserRepository { get; }
        public IApplicationUserRepository ApplicationUserRepository { get; }
        public IApplicationUserTokenRepository ApplicationUserTokenRepository { get; }

        #endregion

        public AuthorizationUnitOfWork
        (
            TransportTicketingNetworkDbContext dbContext,
            IUserRepository userRepository,
            IApplicationUserRepository applicationUserRepository,
            IApplicationUserTokenRepository applicationUserTokenRepository
        ) : base(dbContext)
        {
            UserRepository = userRepository;
            ApplicationUserRepository = applicationUserRepository;
            ApplicationUserTokenRepository = applicationUserTokenRepository;
        }
    }
}

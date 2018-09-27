using Modules.Main.Core.DataAccess;
using Modules.Main.Core.Repositories;
using Common.Base.DataAccess;
using TransportTicketingNetwork.Database;

namespace Modules.Main.DataAccess
{
    public class MainUnitOfWork : UnitOfWork, IMainUnitOfWork
    {
        #region Repositories

        public IUserRepository UserRepository { get; }
        public IApplicationUserRepository ApplicationUserRepository { get; }

        public IBusRepository BusRepository { get; }

        public IJourneyRepository JourneyRepository { get; }

        public IRouteRepository RouteRepository { get; }

        #endregion

        public MainUnitOfWork
        (
            TransportTicketingNetworkDbContext dbContext,
            IUserRepository userRepository,
            IApplicationUserRepository applicationUserRepository,
            IBusRepository busRepository,
            IJourneyRepository journeyRepository,
            IRouteRepository routeRepository


            
        ) : base(dbContext)
        {
            UserRepository = userRepository;
            ApplicationUserRepository = applicationUserRepository;
            BusRepository = busRepository;
            JourneyRepository = journeyRepository;
            RouteRepository = routeRepository;
        }
    }
}

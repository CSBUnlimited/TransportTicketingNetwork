using Common.Core.DataAccess;
using Modules.Main.Core.Repositories;

namespace Modules.Main.Core.DataAccess
{
    public interface IMainUnitOfWork : IUnitOfWork
    {
        #region Repositories

        IUserRepository UserRepository { get; }
        IApplicationUserRepository ApplicationUserRepository { get; }
        IBusRepository BusRepository { get; }
        IRouteRepository RouteRepository { get; }
        IBusScheduleRepository BusScheduleRepository { get; }
        IJourneyRepository JourneyRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }

        #endregion
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.DataAccess;
using Modules.Main.Core.Repositories;
using Modules.Main.Models;

namespace Modules.Main.Core.DataAccess
{
    public interface IMainUnitOfWork : IUnitOfWork
    {
        #region Repositories

        IUserRepository UserRepository { get; }
        IBusRepository BusRepository { get; }
        IRouteRepository RouteRepository { get; }
        IBusScheduleRepository BusScheduleRepository { get; }
        IJourneyRepository JourneyRepository { get; }


        #endregion
    }
}

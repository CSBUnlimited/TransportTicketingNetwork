using Common.Core.DataAccess;
using Modules.Main.Core.Repositories;

namespace Modules.Main.Core.DataAccess
{
    public interface IMainUnitOfWork : IUnitOfWork
    {
        #region Repositories

        IUserRepository UserRepository { get; }
        IBusRepository BusRepository { get; }


        #endregion
    }
}

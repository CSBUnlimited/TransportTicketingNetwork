using Modules.Main.Core.DataAccess;
using Modules.Main.Core.Repositories;
using Modules.Main.Database;
using Common.Base.DataAccess;

namespace Modules.Main.DataAccess
{
    public class MainUnitOfWork : UnitOfWork, IMainUnitOfWork
    {
        #region Repositories

        public IUserRepository UserRepository { get; }

        #endregion

        public MainUnitOfWork
        (
            MainDbContext dbContext,
            IUserRepository userRepository
        ) : base(dbContext)
        {
            #region Repositories

            UserRepository = userRepository;

            #endregion

            #region DbContext

            UserRepository.DbContext = dbContext;

            #endregion
        }
    }
}

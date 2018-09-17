using Modules.Main.Core.DataAccess;
using Modules.Main.Core.Services;

namespace Modules.Main.Services
{
    public class UserService : IUserService
    {
        private IMainUnitOfWork _mainUnitOfWork;

        public UserService(IMainUnitOfWork mainUnitOfWork)
        {
            _mainUnitOfWork = mainUnitOfWork;
        }
    }
}

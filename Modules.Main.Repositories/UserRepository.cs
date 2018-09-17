using Common.Base.Repositories;
using Modules.Main.Core.Repositories;
using Modules.Main.Database;
using Modules.Main.Models;

namespace Modules.Main.Repositories
{
    public class UserRepository : BaseRepository<MainDbContext>, IUserRepository
    {

    }
}

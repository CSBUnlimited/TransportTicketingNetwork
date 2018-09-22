using Common.Base.Repositories;
using Modules.Main.Core.Repositories;
using Modules.Main.Database;
using Modules.Main.Models;

namespace Modules.Main.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        protected new MainDbContext DbContext { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">MainDbContext</param>
        public UserRepository(MainDbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
        }
    }
}

using System;
using System.Threading.Tasks;
using Common.Base.Repositories;
using Microsoft.EntityFrameworkCore;
using Modules.Main.Core.Repositories;
using Modules.Main.Database;
using Modules.Main.Models;

namespace Modules.Main.Repositories
{
    public class ApplicationUserRepository : BaseRepository, IApplicationUserRepository
    {
        protected new MainDbContext DbContext { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">MainDbContext</param>
        public ApplicationUserRepository(MainDbContext dbContext) : base(dbContext)
        {
            DbContext = dbContext;
        }

        /// <summary>
        /// Get Application User by Username witch is not expired - Async
        /// </summary>
        /// <param name="username">Username needed</param>
        /// <returns>If found then Application User otherwise null</returns>
        public async Task<ApplicationUser> GetApplicationUserByUserNameAsync(string username)
        {
            return await DbContext.ApplicationUsers.FirstOrDefaultAsync(au => au.Username == username && au.EffectiveDateTime <= DateTime.Now && au.ExpireDateTime > DateTime.Now);
        }
    }
}

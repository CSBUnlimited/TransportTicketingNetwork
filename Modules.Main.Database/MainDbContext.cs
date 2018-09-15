using Microsoft.EntityFrameworkCore;
using Modules.Main.Models;

namespace Modules.Main.Database
{
    public class MainDbContext : DbContext
    {
        #region DbSets

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationUserToken> ApplicationUserTokens { get; set; }

        #endregion

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Database Table Configuration



            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}

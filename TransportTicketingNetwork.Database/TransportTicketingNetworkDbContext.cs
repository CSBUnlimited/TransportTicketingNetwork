using Common.Models;
using Microsoft.EntityFrameworkCore;
using Modules.Main.Models;
using TransportTicketingNetwork.Database.TableConfigurations.USM;

namespace TransportTicketingNetwork.Database
{
    public class TransportTicketingNetworkDbContext : DbContext
    {
        #region DbSets

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationUserToken> ApplicationUserTokens { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Route> Routes { get; set; }

        #endregion

        public TransportTicketingNetworkDbContext(DbContextOptions<TransportTicketingNetworkDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Database Table Configuration

            #region USM

            modelBuilder.ApplyConfiguration(new ApplicationUserTableConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationUserTokenTableConfiguration());
            modelBuilder.ApplyConfiguration(new UserTableConfiguration());

            #endregion

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}

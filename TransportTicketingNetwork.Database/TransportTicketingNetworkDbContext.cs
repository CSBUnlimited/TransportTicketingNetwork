using Common.Models;
using Microsoft.EntityFrameworkCore;
using Modules.Main.Models;
using TransportTicketingNetwork.Database.TableConfigurations.CMN;
using TransportTicketingNetwork.Database.TableConfigurations.DBO;
using TransportTicketingNetwork.Database.TableConfigurations.USM;

namespace TransportTicketingNetwork.Database
{
    public class TransportTicketingNetworkDbContext : DbContext
    {
        #region DbSets

        #region CMN

        public DbSet<MultiPurposeTagType> MultiPurposeTagTypes { get; set; }
        public DbSet<MultiPurposeTag> MultiPurposeTags { get; set; }

        #endregion

        #region USM

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationUserToken> ApplicationUserTokens { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserExt> UserExts { get; set; }

        #endregion

        #region DBO

        public DbSet<Bus> Buses { get; set; }
        public DbSet<BusSchedule> BusSchedules { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Payment> Payments { get; set; }

        #endregion

        #endregion

        public TransportTicketingNetworkDbContext(DbContextOptions<TransportTicketingNetworkDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Database Table Configuration

            #region CMN

            modelBuilder.ApplyConfiguration(new MultiPurposeTagTypeTableConfiguration());
            modelBuilder.ApplyConfiguration(new MultiPurposeTagTableConfiguration());

            #endregion

            #region USM

            modelBuilder.ApplyConfiguration(new ApplicationUserTableConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationUserTokenTableConfiguration());
            modelBuilder.ApplyConfiguration(new UserTableConfiguration());
            modelBuilder.ApplyConfiguration(new UserExtTableConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleTableConfiguration());

            #endregion

            #region DBO

            modelBuilder.ApplyConfiguration(new PaymentTableConfiguration());

            #endregion

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}

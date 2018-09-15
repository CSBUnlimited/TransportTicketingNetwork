using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Modules.Main.Database
{
    public class MainDbContextForMigrations : IDesignTimeDbContextFactory<MainDbContext>
    {
        //public MainDbContext Create(DbContextFactoryOptions options)
        //{
        //    var builder = new DbContextOptionsBuilder<MainDbContext>();
        //    builder.UseSqlServer("Data Source=CSBUNLIMITED-PC\\CSBSQLSERVER; Integrated Security=SSPI; Initial Catalog=MyDatabase;",
        //        optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(MainDbContext).GetTypeInfo().Assembly.GetName().Name));
        //    return new MainDbContext(builder.Options);
        //}

        public MainDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MainDbContext>();
            builder.UseSqlServer("Data Source=CSBUNLIMITED-PC\\CSBSQLSERVER; Integrated Security=SSPI; Initial Catalog=TransportTicketingNetwork;",
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(MainDbContext).GetTypeInfo().Assembly.GetName().Name));
            return new MainDbContext(builder.Options);
        }
    }
}

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TransportTicketingNetwork.Database
{
    public class TicketingNetworkDbContextForMigrations : IDesignTimeDbContextFactory<TransportTicketingNetworkDbContext>
    {
        private readonly IConfiguration _configuration;

        public TicketingNetworkDbContextForMigrations()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("context-settings", true)
                .AddJsonFile("appsettings.json", true)
                .Build();
        }

        public TransportTicketingNetworkDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<TransportTicketingNetworkDbContext> builder = new DbContextOptionsBuilder<TransportTicketingNetworkDbContext>();
            builder.UseSqlServer(_configuration.GetConnectionString("Default"),
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(TransportTicketingNetworkDbContext).GetTypeInfo().Assembly.GetName().Name));
            return new TransportTicketingNetworkDbContext(builder.Options);
        }
    }
}

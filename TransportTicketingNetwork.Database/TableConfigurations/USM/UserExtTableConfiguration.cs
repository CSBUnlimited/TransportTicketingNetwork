using Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Main.Models;

namespace TransportTicketingNetwork.Database.TableConfigurations.USM
{
    public class UserExtTableConfiguration : IEntityTypeConfiguration<UserExt>
    {
        public void Configure(EntityTypeBuilder<UserExt> builder)
        {
            builder.HasBaseType<User>();
        }
    }
}

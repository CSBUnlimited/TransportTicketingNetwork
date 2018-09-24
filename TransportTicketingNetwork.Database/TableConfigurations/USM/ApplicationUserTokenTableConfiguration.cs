using Common.Configurations.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Main.Models;

namespace TransportTicketingNetwork.Database.TableConfigurations.USM
{
    public class ApplicationUserTokenTableConfiguration : IEntityTypeConfiguration<ApplicationUserToken>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserToken> builder)
        {
            builder.ToTable("ApplicationUserTokens", "usm");

            builder.Property(au => au.TokenHash).IsRequired();

            builder.Property(u => u.EffectiveDateTime).HasDefaultValueSql(DatabaseConstants.CurrentUtcDateTimeValueSql);

            builder.Property(u => u.ExpireDateTime).HasDefaultValueSql(DatabaseConstants.ExpireUtcDateTimeValueSql);

            builder.HasOne(au => au.ApplicationUser).WithMany(aut => aut.ApplicationUserTokens)
                .HasForeignKey(au => au.ApplicationUserId)
                .IsRequired();
        }
    }
}

using Common.Configurations.Constants;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TransportTicketingNetwork.Database.TableConfigurations.USM
{
    public class ApplicationUserTableConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("ApplicationUsers", "usm");

            builder.HasIndex(au => au.Username).IsUnique();
            builder.Property(au => au.Username)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(u => u.PasswordHash).IsRequired();

            builder.Property(u => u.PasswordSalt).IsRequired();

            builder.Property(u => u.EffectiveDateTime).HasDefaultValueSql(DatabaseConstants.CurrentUtcDateTimeValueSql);

            builder.Property(u => u.ExpireDateTime).HasDefaultValueSql(DatabaseConstants.ExpireUtcDateTimeValueSql);
        }
    }
}

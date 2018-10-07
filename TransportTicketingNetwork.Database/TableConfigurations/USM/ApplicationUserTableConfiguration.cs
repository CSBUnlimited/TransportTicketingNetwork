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

            builder.Property(au => au.PasswordHash).IsRequired();

            builder.Property(au => au.PasswordSalt).IsRequired();

            builder.Property(au => au.EffectiveDateTime).HasDefaultValueSql(DatabaseConstants.CurrentUtcDateTimeValueSql);

            builder.Property(au => au.ExpireDateTime).HasDefaultValueSql(DatabaseConstants.ExpireUtcDateTimeValueSql);

            builder.HasOne(au => au.UserRole)
                .WithMany(ur => ur.ApplicationUsers)
                .HasForeignKey(au => au.UserRoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

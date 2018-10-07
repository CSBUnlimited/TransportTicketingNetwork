using Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TransportTicketingNetwork.Database.TableConfigurations.USM
{
    class UserRoleTableConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRoles", "usm");

            builder.Property(ur => ur.Description)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(ur => ur.UserRoleEnum)
                .IsRequired();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Main.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TransportTicketingNetwork.Database.TableConfigurations.BSM
{
    public class BusTableConfiguration : IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> builder)
        {
            builder.ToTable("Buses", "bsm");

            //Id Mapping with auto increment

            builder.Property(b => b.BusName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(b => b.BusNumber)
                .HasMaxLength(5)
                .IsRequired();

            builder.Property(b => b.BusType)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(b => b.NoSeats)
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(b => b.Description)
                .HasMaxLength(250)
                .IsRequired();



            //builder.HasOne(u => u.ApplicationUser).WithOne(au => au.User).HasForeignKey<User>(u => u.ApplicationUserId);

        }
    }
}

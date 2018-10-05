using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Main.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TransportTicketingNetwork.Database.TableConfigurations.BSM
{
    public class BusScheduleTableConfiguration : IEntityTypeConfiguration<BusSchedule>
    {
        public void Configure(EntityTypeBuilder<BusSchedule> builder)
        {
            builder.ToTable("BusSchedules", "bssm");

            //Id Mapping with auto increment

            builder.Property(b => b.StartingPoint)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(b => b.Destination)
                .HasMaxLength(100)
                .IsRequired();

            //Start Time, End Time,Total Duration

            //builder.HasOne(u => u.ApplicationUser).WithOne(au => au.User).HasForeignKey<User>(u => u.ApplicationUserId);

        }
    }
}

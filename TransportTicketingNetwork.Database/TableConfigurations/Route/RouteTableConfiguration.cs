using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Modules.Main.Models;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TransportTicketingNetwork.Database.TableConfigurations.Route
{
    public class RouteTableConfiguration : IEntityTypeConfiguration<Modules.Main.Models.Route>
    {

        public void Configure(EntityTypeBuilder<Modules.Main.Models.Route> builder)
        {

            builder.Property(u => u.Description)
             .HasMaxLength(100)
             .IsRequired();

            builder.Property(u => u.StartBusStopId)
                .HasMaxLength(10)
                .IsRequired();

          

           

        }

    }
}

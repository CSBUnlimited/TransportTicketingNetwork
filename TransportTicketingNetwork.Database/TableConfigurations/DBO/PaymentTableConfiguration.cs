using Common.Configurations.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Main.Models;

namespace TransportTicketingNetwork.Database.TableConfigurations.DBO
{
    public class PaymentTableConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(p => p.ReferenceNo)
                .HasColumnType("CHAR(24)")
                .IsFixedLength()
                .IsRequired();

            builder.Property(p => p.TransactionDateTime).HasDefaultValueSql(DatabaseConstants.CurrentUtcDateTimeValueSql);

            builder.HasOne(p => p.User)
                .WithMany(ue => ue.Payments)
                .HasForeignKey(p => p.UserId);

            builder.HasOne(p => p.ApprovedUser)
                .WithMany(ue => ue.ApprovedPayments)
                .HasForeignKey(p => p.ApprovedUserId);
        }
    }
}

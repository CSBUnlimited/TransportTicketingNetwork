using Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TransportTicketingNetwork.Database.TableConfigurations.CMN
{
    public class MultiPurposeTagTypeTableConfiguration : IEntityTypeConfiguration<MultiPurposeTagType>
    {
        public void Configure(EntityTypeBuilder<MultiPurposeTagType> builder)
        {
            builder.ToTable("MultiPurposeTagTypes", "cmn");

            builder.Property(mpt => mpt.Description)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(mpt => mpt.EnumName)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}

using Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TransportTicketingNetwork.Database.TableConfigurations.CMN
{
    public class MultiPurposeTagTableConfiguration : IEntityTypeConfiguration<MultiPurposeTag>
    {
        public void Configure(EntityTypeBuilder<MultiPurposeTag> builder)
        {
            builder.ToTable("MultiPurposeTags", "cmn");

            builder.Property(mpt => mpt.Description)
                .HasMaxLength(100);

            builder.Property(mpt => mpt.EnumValue)
                .IsRequired();

            builder.HasOne(mpt => mpt.MultiPurposeTagType).WithMany(mptt => mptt.MultiPurposeTags).HasForeignKey(mpt => mpt.MultiPurposeTagTypeId);
        }
    }
}

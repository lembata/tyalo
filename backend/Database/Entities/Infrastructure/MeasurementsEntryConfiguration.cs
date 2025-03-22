using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tyalo.Database.Entities.Infrastructure;

internal sealed class MeasurementsEntryConfiguration  : IEntityTypeConfiguration<MeasurementsEntry>
{
    public void Configure(EntityTypeBuilder<MeasurementsEntry> builder)
    {
        builder.Property(e => e.Weight).IsRequired();
        builder.Property(e => e.UserId).IsRequired();
        builder.HasOne(r => r.User)
            .WithMany()
            .HasForeignKey(r => r.UserId);
    }
}
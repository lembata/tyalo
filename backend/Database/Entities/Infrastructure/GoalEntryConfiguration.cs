using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tyalo.Database.Entities.Infrastructure;

internal sealed class GoalEntryConfiguration  : IEntityTypeConfiguration<GoalEntry>
{
    public void Configure(EntityTypeBuilder<GoalEntry> builder)
    {
        builder.Property(e => e.StartingWeight).IsRequired();
        builder.Property(e => e.UserId).IsRequired();
        builder.HasOne(r => r.User)
            .WithMany()
            .HasForeignKey(r => r.UserId);
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tyalo.Database.Entities.Infrastructure;

internal sealed class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.Property(e => e.Token)
            .IsRequired()
            .HasMaxLength(256);

        builder.HasIndex(e => e.Token)
            .IsUnique();

        builder.HasOne(r => r.User)
            .WithMany()
            .HasForeignKey(r => r.UserId);
    }
}
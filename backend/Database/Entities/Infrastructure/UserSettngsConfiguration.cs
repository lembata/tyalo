using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tyalo.Database.Entities.Infrastructure;

internal sealed class UserSettingsConfiguration  : IEntityTypeConfiguration<UserSettings>
{
    public void Configure(EntityTypeBuilder<UserSettings> builder)
    {
        builder.HasOne(r => r.User)
            .WithOne(u => u.UserSettings)
            .HasForeignKey<UserSettings>(s => s.UserId);
    }
}

using Microsoft.EntityFrameworkCore;
using Tyalo.Database.Entities;

namespace Tyalo.Database;

public class TyaloDbContext(DbContextOptions<TyaloDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<MeasurementsEntry> MeasurementsEntries { get; set; }
    public DbSet<GoalEntry> GoalEntries { get; set; }
    public DbSet<UserSettings> UserSettings { get; set; }
}
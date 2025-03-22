using System.Security.Cryptography;
using Tyalo.Database;
using Tyalo.Database.Entities;

namespace Tyalo.Services;

public class RefreshTokenGenerator(TyaloDbContext db)
{
    public async Task<string> GenerateToken(User user)
    {
        var token = new RefreshToken
        {
            User = user,
            Expires = DateTime.UtcNow.AddDays(30),
            Token = RandomNumberGenerator.GetHexString(256, true)
        };

        db.RefreshTokens.Add(token);
        await db.SaveChangesAsync();

        return token.Token;
    }
}
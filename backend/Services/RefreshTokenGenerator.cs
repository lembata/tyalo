using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
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
            Token = GenerateTokenValue()
        };

        db.RefreshTokens.Add(token);
        await db.SaveChangesAsync();

        return token.Token;
    }

    public async Task<(RefreshToken?, string?)> RegenerateToken(string oldToken)
    {
        RefreshToken? token = await db.RefreshTokens
            .Include(t => t.User)
            .FirstOrDefaultAsync(t => t.Token == oldToken);

        if (token is null)
        {
            return (token, "Token not found");
        }

        if (token.Revoked)
        {
            return (token, "Token revoked");
        }

        if (token.Expires < DateTime.UtcNow)
        {
            return (token, "Token expired");
        }

        token.Token = GenerateTokenValue();
        await db.SaveChangesAsync();

        return (token, null);
    }

    string GenerateTokenValue()
    {
        return RandomNumberGenerator.GetHexString(256, true);
    }
}
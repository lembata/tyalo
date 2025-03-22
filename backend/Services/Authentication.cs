using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Tyalo.Database;
using Tyalo.Database.Entities;

namespace Tyalo.Services;

public class Authentication(
    TyaloDbContext db,
    ITokenGenerator tokenGenerator,
    RefreshTokenGenerator refreshTokenGenerator)
{
    public class LoginRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

    public class LoginResponse
    {
        [JsonPropertyName("access_token")] public required string AccessToken { get; init; }
        [JsonPropertyName("refresh_token")] public required string RefreshToken { get; init; }
    }

    public async Task RegisterUser(LoginRequest request)
    {
        User user = new User
        {
            Email = request.Email,
            Salt = Password.GenerateSalt(),
            PasswordHash = Password.Hash(request.Password, Password.GenerateSalt())
        };

        db.Users.Add(user);
        await db.SaveChangesAsync();
    }

    public async Task<LoginResponse?> Login(LoginRequest request)
    {
        User? user = await db.Users
            .FirstOrDefaultAsync(u => u.Email == request.Email);

        if (user is null)
        {
            return null;
        }

        if (!Password.Verify(request.Password, user.Salt, user.PasswordHash))
        {
            return null;
        }

        return new LoginResponse
        {
            AccessToken = tokenGenerator.GenerateToken(user.Id, user.Email),
            RefreshToken = await refreshTokenGenerator.GenerateToken(user),
        };
    }


    public async Task<LoginResponse?> RefreshToken(string refreshToken)
    {
        if (string.IsNullOrWhiteSpace(refreshToken))
        {
            return null;
        }

        RefreshToken? token = await db.RefreshTokens
            .Include(t => t.User)
            .FirstOrDefaultAsync(t => t.Token == refreshToken);

        if (token is null || token.Revoked)
        {
            return null;
        }

        if (token.Expires < DateTime.UtcNow)
        {
            db.RefreshTokens.Remove(token);
            await db.SaveChangesAsync();
            //TODO: return a hint that the token has expired
            return null;
        }

        return new LoginResponse
        {
            AccessToken = tokenGenerator.GenerateToken(token.User!.Id, token.User.Email),
            RefreshToken = refreshToken,
        };
    }
}
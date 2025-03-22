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

    public async Task<string?> RegisterUser(LoginRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
        {
            return  "Email and password are required";
        }

        if (await db.Users.AnyAsync(u => u.Email == request.Email))
        {
            return "User with this email already exists";
        }

        var salt = Password.GenerateSalt();

        User user = new User
        {
            Email = request.Email,
            Salt = salt,
            PasswordHash = Password.Hash(request.Password, salt)
        };

        db.Users.Add(user);
        await db.SaveChangesAsync();
        return null;
    }

    public async Task<(LoginResponse? response,  string? errorMessage)> Login(LoginRequest request)
    {
        User? user = await db.Users
            .FirstOrDefaultAsync(u => u.Email == request.Email);

        if (user is null)
        {
            return (null, "User not found");
        }

        if (!Password.Verify(request.Password, user.Salt, user.PasswordHash))
        {
            return (null, "Invalid password");
        }

        return (new LoginResponse
        {
            AccessToken = tokenGenerator.GenerateToken(user.Id, user.Email),
            RefreshToken = await refreshTokenGenerator.GenerateToken(user),
        }, null);
    }


    public async Task<(LoginResponse?, string?)> RefreshToken(string refreshToken)
    {
        if (string.IsNullOrWhiteSpace(refreshToken))
        {
            return (null, "Refresh token is required");
        }

        (var newRefresh, string? error) = await refreshTokenGenerator
            .RegenerateToken(refreshToken);

        if (newRefresh is null || error is not null)
        {
            return (null, error ?? "Unknown error");
        }

        return (new LoginResponse
        {
            AccessToken = tokenGenerator.GenerateToken(newRefresh.User!.Id, newRefresh.User.Email),
            RefreshToken = refreshToken,
        }, null);
    }
}
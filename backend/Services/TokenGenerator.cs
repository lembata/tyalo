using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Tyalo.Services;

public interface ITokenGenerator
{
    public string GenerateToken(long userId, string userEmail);
}

public class TokenGenerator(byte[] key) : ITokenGenerator
{
    public string GenerateToken(long userId, string userEmail)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
                new Claim( JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Email, userEmail)
            ]),
            Issuer = "http://tyalo.lembata.pro",
            Audience = "http://tyalo.lembata.pro",
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public string GenerateRefreshToken()
    {
        return Guid.NewGuid().ToString();
    }
}
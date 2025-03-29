using System.ComponentModel.DataAnnotations.Schema;

namespace Tyalo.Database.Entities;

public record RefreshToken : Entity
{
    public long UserId { get; set; }
    public User? User { get; set; }
    public DateTime Expires { get; set; }
    public bool Revoked { get; set; }
    public required string Token { get; set; }
}
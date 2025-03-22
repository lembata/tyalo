using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Tyalo.Database.Entities;

public record User : Entity
{
    public required string Email { get; set; }
    public byte[] PasswordHash { get; set; } = [];
    public byte[] Salt { get; set; } = [];
}
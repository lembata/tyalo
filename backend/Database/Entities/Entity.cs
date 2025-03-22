using System.ComponentModel.DataAnnotations;

namespace Tyalo.Database.Entities;

public abstract record Entity
{
    [Key]
    public long Id { get; set; }
}
namespace Tyalo.Database.Entities;

public record UserSettings : Entity
{
	public long UserId { get; set; }
	public User? User { get; set; }
	public double Height { get; set; }
	public double StartingWeight { get; set; }
	public double GoalWeight { get; set; }
	public double GoalPercentage { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime ModifiedAt { get; set; }
	public LengthUnit LengthUnit { get; set; }
	public WeightUnit WeightUnit { get; set; }
}
namespace Tyalo.Database.Entities;

public record MeasurementsEntry : Entity
{
	public User? User { get; set; }
	public long UserId { get; set; }
	public double Weight { get; set; }
	public double? Neck { get; set; }
	public double? Chest { get; set; }
	public double? NaturalWaist { get; set; }
	public double? Waist { get; set; }
	public double? Thigh { get; set; }
	public double? Arm { get; set; }
	public double? BodyFatPercentage { get; set; }
	public int CaloriesConsumed { get; set; }
	public int CaloriesBurned { get; set; }
	public DateTime Date { get; set; }
	public LengthUnit LengthUnit { get; set; }
	public WeightUnit WeightUnit { get; set; }
	public DateTime DateCreated { get; set; }
	public DateTime DateModified { get; set; }
}

public enum LengthUnit
{
	Centimeters,
	Inches
}

public enum WeightUnit
{
	Kilograms,
	Pounds
}
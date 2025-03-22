namespace Tyalo.Database.Entities;

public record GoalEntry : Entity
{
	public double StartingWeight { get; set; }
	public double TargetWeight { get; set; }
	public double WeeklyGoal { get; set; }
	public DateTime StartDate { get; set; }
	public long UserId { get; set; }
	public User User { get; set; }
}
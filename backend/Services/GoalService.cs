using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tyalo.Database;
using Tyalo.Database.Entities;

namespace Tyalo.Services;

public class GoalService(TyaloDbContext db)
{
	public record GoalEntryDTO
	{
		public double StartingWeight { get; set; }
		public double TargetWeight { get; set; }
		public double WeeklyGoal { get; set; }
		public DateTime StartDate { get; set; }

		public static GoalEntryDTO FromEntity(GoalEntry entity)
		{
			return new GoalEntryDTO
			{
				StartingWeight = entity.StartingWeight,
				TargetWeight = entity.TargetWeight,
				WeeklyGoal = entity.WeeklyGoal,
				StartDate = entity.StartDate
			};
		}

		public static GoalEntry ToEntity(GoalEntryDTO dto, long userId)
		{
			return new GoalEntry
			{
				StartingWeight = dto.StartingWeight,
				TargetWeight = dto.TargetWeight,
				WeeklyGoal = dto.WeeklyGoal,
				StartDate = dto.StartDate,
			};
		}

		public void UpdateEntity(GoalEntry entity)
		{
			entity.StartingWeight = StartingWeight;
			entity.TargetWeight = TargetWeight;
			entity.WeeklyGoal = WeeklyGoal;
			entity.StartDate = StartDate;
		}
	}

	public async Task<(GoalEntry?, string? error)> GetLastGoal(long userId)
	{
		var goal = await db.GoalEntries
			.OrderByDescending(g => g.StartDate)
			.Where(g => g.UserId == userId)
			.FirstOrDefaultAsync();

		if (goal is null)
		{
			return (null, "No goals found");
		}

		return (goal, null);
	}

	public async Task<GoalEntry[]> GetGoalList(long userId, DateTime startDate, DateTime endDate)
	{
		var goal = await db.GoalEntries
			.Where(g => g.StartDate >= startDate)
			.Where(g => g.StartDate <= endDate)
			.Where(g => g.UserId == userId)
			.ToArrayAsync();

		return goal ?? [];
	}

	public async Task<(GoalEntry?, string?)> AddOrUpdateGoal(long userId, GoalEntryDTO dto)
	{
		var goal = await db.GoalEntries
			.Where(g => g.StartDate == dto.StartDate.ToUniversalTime().Date)
			.Where(g => g.UserId == userId)
			.FirstOrDefaultAsync();


		if (goal is null)
		{
			goal = GoalEntryDTO.ToEntity(dto, userId);
			var user = new User() { Id = userId };
			db.Users.Attach(user);
			goal.User = user;
			db.GoalEntries.Add(goal);
		}
		else
		{
			dto.UpdateEntity(goal);
		}

		await db.SaveChangesAsync();
		return (goal, null);
	}
}
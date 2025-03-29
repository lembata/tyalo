using Microsoft.AspNetCore.Mvc;
using Tyalo.Services;

namespace Tyalo.Controllers;

[ApiController]
[Route("/api/goal")]
public class GoalController(GoalService goalService) : AuthorizedController
{

	[HttpGet("/last")]
	public async Task<IActionResult> GetGoalLast()
	{
		(var data, string? error) = await goalService.GetLastGoal(UserId);

		if (error is not null)
		{
			return Failure(error);
		}

		return Data(data);
	}

	[HttpGet("/list")]
	public async Task<IActionResult> GetGoalList(DateTime from, DateTime to)
	{
		var data = await goalService.GetGoalList(UserId, from, to);
		return Data(data);
	}

	[HttpPatch("/")]
	public async Task<IActionResult> UpdateGoal(GoalService.GoalEntryDTO goal)
	{
		var (data, error) = await goalService.AddOrUpdateGoal(UserId, goal);

		if (error is not null)
		{
			return Failure(error);
		}

		return Data(data);
	}
}
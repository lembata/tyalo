using Microsoft.AspNetCore.Mvc;
using Tyalo.Services;

namespace Tyalo.Controllers;

[ApiController]
[Route("/api/settings")]
public class SettingsController(SettingsService SettingsService) : AuthorizedController
{
	[HttpGet("")]
	public async Task<IActionResult> GetSettings()
	{
		var settings = await SettingsService.GetSettings(UserId);

		if (settings is null)
		{
			return Failure("Settings not found");
		}

		return Data(settings);
	}

	[HttpPatch("")]
	public async Task<IActionResult> SaveSettings([FromBody] SettingsService.UserSettingsDto settings)
	{
		var result = await SettingsService.UpdateSettings(UserId, settings);

		// if (settings is null)
		// {
		// 	return Failure("Settings not found");
		// }
		//
		return Data(settings);
	}
}
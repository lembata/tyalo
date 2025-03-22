using Microsoft.AspNetCore.Mvc;
using Tyalo.Services;

namespace Tyalo.Controllers;

[ApiController]
[Route("api/authentication")]
public class AuthenticationController : Controller
{
	[HttpPost("register")]
	public async Task<IActionResult> RegisterUser([FromServices] Authentication authentication,
		[FromServices] IConfiguration configuration, [FromBody] Authentication.LoginRequest request)
	{
		if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
		{
			return BadRequest();
		}

		if (!configuration.GetValue("AllowRegistration", false))
		{
			return Forbid();
		}

		await authentication.RegisterUser(request);
		return Ok();
	}

	[HttpPost("login")]
	public async Task<IActionResult> Login([FromServices] Authentication authentication,
		[FromBody] Authentication.LoginRequest request)
	{
		var result = await authentication.Login(request);

		if (result is null)
		{
			return Unauthorized();
		}

		return Json(result);
	}

	[HttpPost("refresh-token")]
	public async Task<IActionResult> RefreshToken([FromServices] Authentication authentication,
		[FromQuery] string refreshToken)
	{
		var result = await authentication.RefreshToken(refreshToken);
		return Json(result);
	}
}
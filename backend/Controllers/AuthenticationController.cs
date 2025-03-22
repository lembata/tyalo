using Microsoft.AspNetCore.Mvc;
using Tyalo.Services;

namespace Tyalo.Controllers;

[ApiController]
[Route("api/authentication")]
public class AuthenticationController : BaseController
{
	[HttpPost("register")]
	public async Task<IActionResult> RegisterUser([FromServices] Authentication authentication,
		[FromServices] IConfiguration configuration, [FromBody] Authentication.LoginRequest request)
	{
		if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
		{
			return Failure("Email and password are required");
		}

		// if (!configuration.GetValue("AllowRegistration", false))
		// {
		// 	return Forbid();
		// }

		var error = await authentication.RegisterUser(request);

		return error is not null
			? Failure(error)
			: Success();
	}

	[HttpPost("login")]
	public async Task<IActionResult> Login([FromServices] Authentication authentication,
		[FromBody] Authentication.LoginRequest request)
	{
		var (result , errorMessage) = await authentication.Login(request);

		if (result is null)
		{
			return Failure(errorMessage ?? "Unknown error");
		}

		return Data(result);
	}

	[HttpPost("refresh")]
	public async Task<IActionResult> RefreshToken([FromServices] Authentication authentication,
		[FromQuery] string refreshToken)
	{
		var (result, error) = await authentication.RefreshToken(refreshToken);
		if (error is not null)
		{
			return Failure(error);
		}
		return Data(result);
	}
}
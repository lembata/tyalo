using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tyalo.Services;

namespace Tyalo.Controllers;

[ApiController]
[Route("api/measurements")]
public class MeasurementsController : AuthorizedController
{

	[Authorize]
	public async Task<IActionResult> AddMeasurement([FromServices] MeasurementsService measurements,
		[FromBody] MeasurementsService.Measurements request)
	{
		var result = await measurements.AddOrUpdateMeasurements(UserId, request);
		if (result is not null)
		{
			return BadRequest(result);
		}

		return Ok();
	}
}
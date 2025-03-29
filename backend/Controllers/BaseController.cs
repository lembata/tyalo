using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace Tyalo.Controllers;

public abstract class BaseController : Controller
{
	record ApiResult(
		[property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		string? Message = null,
		bool Success = false
	);

	record ApiResult<T>(
		[property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		string? Message = null,
		[property:JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		T? Data = default(T),
		bool Success = false
	);

	protected IActionResult Success()
	{
		return Json(new ApiResult(Success: true));
	}

	protected IActionResult Failure(string message)
	{
		Response.StatusCode = StatusCodes.Status400BadRequest;
		return Json(new ApiResult(Message: message, Success: false));
	}

	protected IActionResult Data<T>(T data)
	{
		return Json(new ApiResult<T>(Data: data, Success: true));
	}
}
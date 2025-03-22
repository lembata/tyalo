using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Tyalo.Services;

namespace Tyalo.Controllers;


public class ValidateUserIdAttribute : Attribute, IAuthorizationFilter
{
	public void OnAuthorization(AuthorizationFilterContext context)
	{
		var user = context.HttpContext.User;
		if (user.Identity is ClaimsIdentity identity)
		{
			var userIdClaim = identity.FindFirst(ClaimTypes.NameIdentifier);
			if (userIdClaim == null || !long.TryParse(userIdClaim.Value, out _))
			{
				context.Result = new UnauthorizedResult();
			}
		}
		else
		{
			context.Result = new UnauthorizedResult();
		}
	}
}

[Authorize]
[ValidateUserId]
public abstract class AuthorizedController : BaseController
{
	public long UserId { get; init; }

	protected AuthorizedController()
	{
		UserId = long.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
	}

}
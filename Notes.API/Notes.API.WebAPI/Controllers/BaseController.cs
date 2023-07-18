using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace Notes.API.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class BaseController : ControllerBase
{
    private IMediator _mediator;
	public BaseController(IMediator mediator)
	{
		_mediator = mediator;
	}

	protected IMediator  Mediator => 
		_mediator ??= HttpContext.RequestServices.GetRequiredService<Mediator>();
    internal Guid UserId => User.Identity.IsAuthenticated ? 
							Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) : 
							Guid.Empty;
}
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Notes.API.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class BaseController : ControllerBase
{
	private IMediator _mediator;
	private IMapper   _mapper;
	public BaseController(IMediator mediator, IMapper mapper)
	{
		_mediator = mediator;
		_mapper = mapper;
	}

	protected IMediator  Mediator => 
		_mediator ??= HttpContext.RequestServices.GetRequiredService<Mediator>();
	protected IMapper Mapper => 
		_mapper ??= HttpContext.RequestServices.GetRequiredService<Mapper>(); 
    internal Guid UserId => User.Identity.IsAuthenticated ? 
							Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) : 
							Guid.Empty;
}
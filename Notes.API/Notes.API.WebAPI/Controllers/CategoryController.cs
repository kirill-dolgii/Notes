using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notes.API.Application.Categories.Commands.CreateCategoryCommand;
using Notes.API.Application.Categories.Commands.DeleteCategoryCommand;
using Notes.API.Application.Categories.Commands.UpdateCategoryCommand;
using Notes.API.Application.Categories.Queries.GetCategoryListQuery;
using Notes.API.Application.Categories.Queries.GetCategoryNotesQuery;
using Notes.API.WebAPI.Models;

namespace Notes.API.WebAPI.Controllers;

[Route("api/[controller]")]
public class CategoryController : BaseController
{
	public CategoryController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

	[HttpPost]
	public async Task<ActionResult<Guid>> Create([FromBody] CreateCategoryDto createCategoryDto)
	{
		var  request = Mapper.Map<CreateCategoryCommand>(createCategoryDto);
		request.UserId = UserId;
		try
		{
			var response = await Mediator.Send(request);
            return Ok(response);
		}
		catch (Exception ex)
		{
			return Problem(detail: ex.Message);
		}
	}

	[HttpGet]
	public async Task<ActionResult<GetCategoryListVm>> GetAll()
	{
		var request = new GetCategoryListQuery()
		{
			UserId = UserId
		};

		var response = await Mediator.Send(request);

        return Ok(response);
	}

	[HttpGet("{categoryId}")]
	public async Task<ActionResult<CategoryNotesVm>> GetCategoryNotes(Guid categoryId)
	{
		var request = new GetCategoryNotesQuery()
		{
			UserId = UserId,
			CategoryId = categoryId
		};

		try
		{
			var response = await Mediator.Send(request);
			return Ok(response);
		}
		catch (Exception ex)
		{
			return Problem(ex.Message);
		}
	}

	[HttpDelete("{categoryId}")]
	public async Task<ActionResult> Delete(Guid categoryId)
	{
		var request = new DeleteCategoryCommand
		{
			Id = categoryId,
			UserId = UserId
		};

		try
		{
			await Mediator.Send(request);
			return Ok();
		}
		catch (Exception ex)
		{
			return Problem(ex.Message);
		}
	}

	[HttpPut]
	public async Task<ActionResult> Update([FromBody] UpdateCategoryDto updateCommandDto)
	{
		var request = new UpdateCategoryCommand
		{
			UserId = UserId,
			Id = updateCommandDto.Id,
			Name = updateCommandDto.Name
		};

		try
		{
			await Mediator.Send(request);
			return Ok();
		}
		catch (Exception ex)
		{
			return Problem(ex.Message);
		}
	}
}
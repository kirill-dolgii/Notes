using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notes.API.Application.Notes.Commands.CreateNote;
using Notes.API.Application.Notes.Commands.DeleteNoteCommand;
using Notes.API.Application.Notes.Commands.UpdateNote;
using Notes.API.Application.Notes.Queries.GetNoteDetailsQuery;
using Notes.API.Application.Notes.Queries.GetNotesListQuery;
using Notes.API.WebAPI.Models;

namespace Notes.API.WebAPI.Controllers;

[Route("api/[controller]")]
public class NoteController : BaseController
{
	private readonly IMapper _mapper;
	public NoteController(IMapper mapper, IMediator mediator) : base(mediator)
	{
		_mapper = mapper;
	}

	[HttpGet]
	public async Task<ActionResult<NoteListVm>> GetAll()
	{
		var request = new GetNotesListQuery
		{
			UserId = UserId
		};
		var response = await Mediator.Send(request);
		return Ok(response);
	}

	[HttpGet("{noteId}")]
	public async Task<ActionResult<NoteDetailsVm>> GetNoteDetails(Guid noteId)
	{
		var request = new GetNoteDetailsQuery
		{
			UserId = UserId,
			Id = noteId
		};

		NoteDetailsVm response;

		try
		{
			response = await Mediator.Send(request);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}

		return response;
	}

	[HttpPost]
	public async Task<ActionResult<Guid>> CreateNote([FromBody] CreateNoteDto createNoteDto)
	{
		var command = _mapper.Map<CreateNoteCommand>(createNoteDto);
		command.UserId = UserId;
		var response = await Mediator.Send(command);
		return Ok(response);
	}

	[HttpPut]
	public async Task<ActionResult> Update([FromBody] UpdateNoteDto updateNoteDto)
	{
		var command  = _mapper.Map<UpdateNoteCommand>(updateNoteDto);
		command.UserId = UserId;
		try
		{
			await Mediator.Send(command);
			return NoContent();
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpDelete("{noteId}")]
	public async Task<ActionResult> Delete(Guid noteId)
	{
		var command = new DeleteNoteCommand()
		{
			Id = noteId
		};
		command.UserId = UserId;

		try
		{
			await Mediator.Send(command);
			return NoContent();
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
}
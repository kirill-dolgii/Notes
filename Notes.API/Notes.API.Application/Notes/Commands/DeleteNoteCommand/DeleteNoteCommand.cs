using MediatR;

namespace Notes.API.Application.Notes.Commands.DeleteNoteCommand;

public class DeleteNoteCommand : IRequest
{
	public Guid UserId { get; set; }
	public Guid Id     { get; set; }
}
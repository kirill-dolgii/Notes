using MediatR;

namespace Notes.API.Application.Notes.Commands.DeleteNoteCommand;

public class DeleteNoteCommand : IRequest
{
	public DeleteNoteCommand(Guid userId, Guid id)
	{
		UserId = userId;
		Id = id;
	}
	public Guid UserId { get; }
    public Guid Id     { get; }
}
using MediatR;
using Notes.API.Application.Common.Exceptions;
using Notes.API.Application.Interfaces;

namespace Notes.API.Application.Notes.Commands.DeleteNoteCommand;

public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
{
	private readonly INotesDbContext _context;
	public DeleteNoteCommandHandler(INotesDbContext context)
	{
		_context = context;
	}

	public async Task Handle(DeleteNoteCommand request, 
							 CancellationToken cancellationToken)
	{
		var note = await _context.Notes.FindAsync(new object[] { request.Id }, cancellationToken);
		if (note == null || note.UserId != request.UserId)
		{
			throw new NotFoundException(nameof(note), request.Id);
		}
		_context.Notes.Remove(note);
		await _context.SaveChangesAsync(cancellationToken);
	}
}
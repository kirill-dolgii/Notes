using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.API.Application.Common.Exceptions;
using Notes.API.Application.Interfaces;

namespace Notes.API.Application.Notes.Commands.UpdateNote;

public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand>
{
	private readonly INotesDbContext _context;
	public UpdateNoteCommandHandler(INotesDbContext context)
	{
		_context = context;
	}

	public async Task Handle(UpdateNoteCommand request, 
							 CancellationToken cancellationToken)
	{
		var note = await _context.Notes.FirstOrDefaultAsync(note => note.Id == request.Id, 
															cancellationToken);
		if (note == null || note.UserId != request.UserId)
		{
			throw new NotFoundException(nameof(note), request.Id);
		}

		note.Title = request.Title;
		note.Description = request.Description;
		note.Category = request.Category;
		note.Tags = request.Tags;
		note.EditionTime = DateTime.Now;

		await _context.SaveChangesAsync(cancellationToken);
	}
}
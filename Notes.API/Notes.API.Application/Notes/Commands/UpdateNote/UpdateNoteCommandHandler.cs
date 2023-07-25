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
		var note = await _context.Notes
					 .FirstOrDefaultAsync(note => note.UserId == request.UserId && 
												  note.Id == request.Id, 
										  cancellationToken);
		if (note == null || note.UserId != request.UserId)
		{
			throw new NotFoundException(nameof(note), request.Id);
		}

		var category = await _context.Categories
						 .FirstOrDefaultAsync(c => c.UserId == request.UserId &&
												   c.Id == request.CategoryId,
											  cancellationToken);

		if (category == null)
		{
			throw new NotFoundException(nameof(category), request.CategoryId);
		}

		note.Title = request.Title;
		note.Description = request.Description;
		note.CategoryId = category.Id;
		note.Category = category;
		note.Tags = request.Tags;
		note.EditionTime = DateTime.Now;

		await _context.SaveChangesAsync(cancellationToken);
	}
}
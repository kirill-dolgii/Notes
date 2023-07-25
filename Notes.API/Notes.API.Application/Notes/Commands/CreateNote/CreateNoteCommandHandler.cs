using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.API.Application.Common.Exceptions;
using Notes.API.Application.Interfaces;
using Notes.API.Domain;

namespace Notes.API.Application.Notes.Commands.CreateNote;

public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Guid>
{
	private readonly INotesDbContext _context;
	public CreateNoteCommandHandler(INotesDbContext context)
	{
		_context = context;
	}

	public async Task<Guid> Handle(CreateNoteCommand request, 
								   CancellationToken cancellationToken)
	{
		var category = await _context.Categories
								 .FirstOrDefaultAsync(c => c.UserId == request.UserId &&
														   c.Id == request.CategoryId, 
													  cancellationToken);

		if (category == null)
		{
			throw new NotFoundException(nameof(category), request.CategoryId);
		}

		var note = new Note
		{
			UserId = request.UserId,
			Title = request.Title,
			Description = request.Description,
			CreationTime = DateTime.Now,
			CategoryId = category.Id,
			Category = category,
			Tags = request.Tags,
		};
		await _context.Notes.AddAsync(note, cancellationToken);
		await _context.SaveChangesAsync(cancellationToken);
		return note.Id;
	}
}
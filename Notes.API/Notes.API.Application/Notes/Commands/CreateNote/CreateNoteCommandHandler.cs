using MediatR;
using Notes.API.Application.Interfaces;
using Notes.API.Domain;

namespace Notes.API.Application.Notes.Commands.CreateNote;

public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Guid>
{
	private readonly INotesDbContext _context;
	public CreateNoteCommandHandler(INotesDbContext context) => _context = context;

	public async Task<Guid> Handle(CreateNoteCommand request, 
								   CancellationToken cancellationToken)
	{
		var note = new Note(request.UserId, request.Title, request.Description);
		await _context.Notes.AddAsync(note, cancellationToken);
		await _context.SaveChangesAsync(cancellationToken);
		return note.Id;
	}
}
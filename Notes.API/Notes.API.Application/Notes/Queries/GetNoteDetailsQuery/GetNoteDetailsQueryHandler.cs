using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.API.Application.Common.Exceptions;
using Notes.API.Application.Interfaces;

namespace Notes.API.Application.Notes.Queries.GetNoteDetailsQuery;

public class GetNoteDetailsQueryHandler : IRequestHandler<GetNoteDetailsQuery, NoteDetailsVm>
{
	private readonly INotesDbContext _context;
	private readonly IMapper _mapper;
	public GetNoteDetailsQueryHandler(INotesDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}

	public async Task<NoteDetailsVm> Handle(GetNoteDetailsQuery request, 
											CancellationToken cancellationToken)
	{
		var note = await _context.Notes
					.Include(note => note.Category)
					.FirstOrDefaultAsync(note => note.UserId == request.UserId && 
												 note.Id == request.Id, cancellationToken);
		
		if (note == null || note.UserId != request.UserId)
		{
			throw new NotFoundException(nameof(note), request.Id);
		}

		return _mapper.Map<NoteDetailsVm>(note);
	}
}
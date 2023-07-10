using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.API.Application.Interfaces;

namespace Notes.API.Application.Notes.Queries.GetNotesListQuery;

public class GetNotesListQueryHandler : IRequestHandler<GetNotesListQuery, NoteListVm>
{
	private readonly IMapper _mapper;
	private readonly INotesDbContext _context;
	public GetNotesListQueryHandler(IMapper mapper, INotesDbContext context)
	{
		_mapper = mapper;
		_context = context;
	}

	public async Task<NoteListVm> Handle(GetNotesListQuery request, 
										 CancellationToken cancellationToken)
	{
		var notes = await _context.Notes.Where(note => note.UserId == request.UserId)
								  .ProjectTo<NoteLookUpDto>(_mapper.ConfigurationProvider)
                                  .ToListAsync(cancellationToken);
		return new NoteListVm
		{
			Notes = notes
		};
    }
}
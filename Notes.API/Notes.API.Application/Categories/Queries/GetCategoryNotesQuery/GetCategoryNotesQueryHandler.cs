using MediatR;
using Notes.API.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using Notes.API.Application.Notes.Queries.GetNotesListQuery;
using AutoMapper;

namespace Notes.API.Application.Categories.Queries.GetCategoryNotesQuery;

public class GetCategoryNotesQueryHandler : IRequestHandler<GetCategoryNotesQuery, CategoryNotesVm>
{
	private readonly INotesDbContext _context;
	private readonly IMapper         _mapper;
	public GetCategoryNotesQueryHandler(INotesDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}

	public async Task<CategoryNotesVm> Handle(GetCategoryNotesQuery request, 
											  CancellationToken cancellationToken)
	{
		var notes = await _context.Notes
					.Where(note => note.UserId == request.UserId &&
													   note.CategoryId == request.CategoryId)
					.ProjectTo<NoteLookUpDto>(_mapper.ConfigurationProvider)
					.ToListAsync(cancellationToken);

		var categoryNotesVm = new CategoryNotesVm()
		{
			Notes = notes,
		};

		return categoryNotesVm;
	}
}
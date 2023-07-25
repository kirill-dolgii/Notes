using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.API.Application.Interfaces;

namespace Notes.API.Application.Categories.Queries.GetCategoryListQuery;

public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, GetCategoryListVm>
{
	private readonly INotesDbContext _context;
	private readonly IMapper _mapper;
	public GetCategoryListQueryHandler(INotesDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}

	public async Task<GetCategoryListVm> Handle(GetCategoryListQuery request, 
												CancellationToken cancellationToken)
	{
		var categories = await _context.Categories
									   .Where(c => c.UserId == request.UserId)
									   .ProjectTo<CategoryLookUpDto>(_mapper.ConfigurationProvider)
									   .ToListAsync(cancellationToken);

		var vm = new GetCategoryListVm()
		{
			Categories = categories
		};

		return vm;
	}
}
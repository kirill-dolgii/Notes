using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.API.Application.Common.Exceptions;
using Notes.API.Application.Interfaces;

namespace Notes.API.Application.Categories.Commands.UpdateCategoryCommand;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
	public readonly INotesDbContext _context;
	public UpdateCategoryCommandHandler(INotesDbContext context)
	{
		_context = context;
	}

	public async Task Handle(UpdateCategoryCommand request, 
							 CancellationToken cancellationToken)
	{
		if (await _context.Categories.AnyAsync(c => c.UserId == request.UserId &&
													c.Name == request.Name,
											   cancellationToken))
		{
			throw new Exception("Category with the name provided already exists");
		}

		var category = await _context.Categories
									 .FirstOrDefaultAsync(c => c.UserId == request.UserId && 
															   c.Id == request.Id, 
														  cancellationToken);

		if (category == null)
		{
			throw new NotFoundException(nameof(category), request.Id);
		}

		category.Name = request.Name;
		await _context.SaveChangesAsync(cancellationToken);
	}
}
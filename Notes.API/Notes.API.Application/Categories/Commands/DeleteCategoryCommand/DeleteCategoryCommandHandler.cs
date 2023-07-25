using MediatR;
using Notes.API.Application.Interfaces;
using Notes.API.Application.Common.Exceptions;

namespace Notes.API.Application.Categories.Commands.DeleteCategoryCommand;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
	private readonly INotesDbContext _context;
	public DeleteCategoryCommandHandler(INotesDbContext context)
	{
		_context = context;
	}

	public async Task Handle(DeleteCategoryCommand request, 
							 CancellationToken cancellationToken)
	{
		var category = await _context.Categories
				   .FindAsync(new object[] { request.Id }, cancellationToken);
		if (category == null || category.UserId != request.UserId)
		{
			throw new NotFoundException(nameof(category), request.Id);
		}

		_context.Categories.Remove(category);
		await _context.SaveChangesAsync(cancellationToken);
	}
}
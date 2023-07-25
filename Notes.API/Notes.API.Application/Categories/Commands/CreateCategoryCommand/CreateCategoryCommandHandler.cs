using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.API.Application.Interfaces;
using Notes.API.Domain;

namespace Notes.API.Application.Categories.Commands.CreateCategoryCommand;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
{
    public CreateCategoryCommandHandler(INotesDbContext context)
    {
        _context = context;
    }

	private readonly INotesDbContext _context;
    public async Task<Guid> Handle(CreateCategoryCommand request,
                                   CancellationToken cancellationToken)
    {
        var category = new Category()
        {
            Name = request.Name,
            UserId = request.UserId
		};

		var existingCategory = await _context.Categories.FirstOrDefaultAsync(
			c => c.UserId == request.UserId && c.Name == request.Name,
			cancellationToken);

        if (existingCategory != null)
		{
			throw new Exception("there is already category with the name provided");
		}

        await _context.Categories.AddAsync(category, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return category.Id;
    }
}
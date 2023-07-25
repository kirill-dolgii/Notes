using MediatR;

namespace Notes.API.Application.Categories.Commands.DeleteCategoryCommand;

public class DeleteCategoryCommand : IRequest
{
    public Guid UserId { get; set; }
	public Guid Id     { get; set; }
}
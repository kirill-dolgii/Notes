using MediatR;

namespace Notes.API.Application.Categories.Commands.UpdateCategoryCommand;

public class UpdateCategoryCommand : IRequest
{
    public Guid UserId { get; set; }
	public Guid Id     { get; set; }
    public string Name { get; set; }
}
using MediatR;

namespace Notes.API.Application.Categories.Commands.CreateCategoryCommand;

public class CreateCategoryCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
}
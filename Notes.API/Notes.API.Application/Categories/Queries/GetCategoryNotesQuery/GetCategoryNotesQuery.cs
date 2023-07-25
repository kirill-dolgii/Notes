using MediatR;

namespace Notes.API.Application.Categories.Queries.GetCategoryNotesQuery;

public class GetCategoryNotesQuery : IRequest<CategoryNotesVm>
{
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
}
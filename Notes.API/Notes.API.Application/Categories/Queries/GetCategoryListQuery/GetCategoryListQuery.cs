using MediatR;

namespace Notes.API.Application.Categories.Queries.GetCategoryListQuery;

public class GetCategoryListQuery : IRequest<GetCategoryListVm>
{
    public Guid UserId { get; set; }
}
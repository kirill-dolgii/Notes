using Notes.API.Application.Notes.Queries.GetNotesListQuery;

namespace Notes.API.Application.Categories.Queries.GetCategoryNotesQuery;

public class CategoryNotesVm
{
    public IList<NoteLookUpDto> Notes { get; set; }
}
using Notes.API.Application.Common.Mapping;
using Notes.API.Domain;

namespace Notes.API.Application.Notes.Queries.GetNotesListQuery;

public class NoteLookUpDto : IMapWith<Note>
{
	public Guid Id { get; set; }
	public string Title { get; set; }
}
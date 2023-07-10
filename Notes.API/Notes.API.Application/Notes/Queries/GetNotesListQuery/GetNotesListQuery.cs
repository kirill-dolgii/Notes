using MediatR;

namespace Notes.API.Application.Notes.Queries.GetNotesListQuery;

public class GetNotesListQuery : IRequest<NoteListVm>
{
	public Guid UserId { get; set; }
}
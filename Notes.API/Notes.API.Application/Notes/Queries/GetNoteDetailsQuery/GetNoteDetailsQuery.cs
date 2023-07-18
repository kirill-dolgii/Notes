using MediatR;

namespace Notes.API.Application.Notes.Queries.GetNoteDetailsQuery;

public class GetNoteDetailsQuery : IRequest<NoteDetailsVm>
{
	public Guid UserId { get; set; }
	public Guid Id     { get; set; }
}
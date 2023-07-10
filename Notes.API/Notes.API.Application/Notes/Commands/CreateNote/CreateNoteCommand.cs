using MediatR;

namespace Notes.API.Application.Notes.Commands.CreateNote;

public class CreateNoteCommand : IRequest<Guid>, IRequest
{
    public Guid   UserId    { get; }
    public string Title { get; }
    public string Description { get; }
}
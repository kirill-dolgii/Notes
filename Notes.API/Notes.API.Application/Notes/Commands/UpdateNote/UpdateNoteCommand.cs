using MediatR;

namespace Notes.API.Application.Notes.Commands.UpdateNote;

public class UpdateNoteCommand : IRequest
{
    public Guid   UserId { get; }
    public Guid   Id     { get; }
    public string Title  { get; }
    public string Description { get; }
}
using MediatR;

namespace Notes.API.Application.Notes.Commands.UpdateNote;

public class UpdateNoteCommand : IRequest
{
    public Guid                UserId      { get; set; }
    public Guid                Id          { get; set; }
    public string              Title       { get; set; }
    public string              Description { get; set; }
    public Guid                CategoryId  { get; set; }
	public ICollection<string> Tags        { get; set; }
}
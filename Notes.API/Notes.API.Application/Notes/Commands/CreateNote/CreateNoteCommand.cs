using MediatR;
using Notes.API.Domain;

namespace Notes.API.Application.Notes.Commands.CreateNote;

public class CreateNoteCommand : IRequest<Guid>
{
    public Guid                UserId      { get; set; }
    public string              Title       { get; set; }
    public string              Description { get; set; }
    public Category            Category    { get; set; }
	public ICollection<string> Tags        { get; set; }
}
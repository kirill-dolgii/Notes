using AutoMapper;
using Notes.API.Application.Common.Mapping;
using Notes.API.Application.Notes.Commands.CreateNote;

namespace Notes.API.WebAPI.Models;

public class CreateNoteDto : IMapWith<CreateNoteCommand>
{
	public string              Title       { get; set; }
	public string              Description { get; set; }
	public Guid                CategoryId  { get; set; }
	public ICollection<string> Tags        { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<CreateNoteDto, CreateNoteCommand>();
	}
}
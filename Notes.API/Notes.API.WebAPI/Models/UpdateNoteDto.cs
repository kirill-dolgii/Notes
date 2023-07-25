using AutoMapper;
using Notes.API.Application.Common.Mapping;
using Notes.API.Application.Notes.Commands.UpdateNote;

namespace Notes.API.WebAPI.Models;

public class UpdateNoteDto : IMapWith<UpdateNoteCommand>
{
    public Guid                Id          { get; set; }
    public string              Title       { get; set; }
    public string              Description { get; set; }
    public Guid                CategoryId  { get; set; }
	public ICollection<string> Tags        { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<UpdateNoteDto, UpdateNoteCommand>();
	}
}
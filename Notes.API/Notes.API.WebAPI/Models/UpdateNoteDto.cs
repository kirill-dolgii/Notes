using AutoMapper;
using Notes.API.Domain;
using Notes.API.Application.Common.Mapping;
using Notes.API.Application.Notes.Commands.UpdateNote;

namespace Notes.API.WebAPI.Models;

public class UpdateNoteDto : IMapWith<UpdateNoteCommand>
{
    public Guid                Id          { get; set; }
    public string              Title       { get; set; }
    public string              Description { get; set; }
    public string              Category    { get; set; }
	public ICollection<string> Tags        { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<UpdateNoteDto, UpdateNoteCommand>()
			   .ForMember(command => command.Category, ops => ops.MapFrom(dto => Enum.Parse<Category>(dto.Category)))
			   .ReverseMap();
	}
}
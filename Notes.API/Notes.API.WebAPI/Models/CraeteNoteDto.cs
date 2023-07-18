using AutoMapper;
using Notes.API.Application.Common.Mapping;
using Notes.API.Application.Notes.Commands.CreateNote;
using Notes.API.Domain;

namespace Notes.API.WebAPI.Models;

public class CreateNoteDto : IMapWith<CreateNoteCommand>
{
	public string              Title       { get; set; }
	public string              Description { get; set; }
	public string              Category    { get; set; }
	public ICollection<string> Tags        { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<CreateNoteDto, CreateNoteCommand>()
			   .ForMember(command => command.Category,
						  opt => opt.MapFrom(dto => Enum.Parse<Category>(dto.Category)));
	}
}
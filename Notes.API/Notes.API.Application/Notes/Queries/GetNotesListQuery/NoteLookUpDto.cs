using AutoMapper;
using Notes.API.Application.Common.Mapping;
using Notes.API.Domain;

namespace Notes.API.Application.Notes.Queries.GetNotesListQuery;

public class NoteLookUpDto : IMapWith<Note>
{
	public Guid                Id       { get; set; }
	public string              Title    { get; set; }
	public string              Category { get; set; }
	public ICollection<string> Tags     { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<NoteLookUpDto, Note>()
			   .ForMember(note => note.Category, ops => ops.MapFrom(dto => Enum.Parse<Category>(dto.Category)))
			   .ReverseMap();
	}
}
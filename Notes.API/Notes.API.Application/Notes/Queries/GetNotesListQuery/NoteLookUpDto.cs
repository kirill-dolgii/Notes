using AutoMapper;
using Notes.API.Application.Common.Mapping;
using Notes.API.Domain;

namespace Notes.API.Application.Notes.Queries.GetNotesListQuery;

public class NoteLookUpDto : IMapWith<Note>
{
	public Guid                Id           { get; set; }
	public string              Title        { get; set; }
	public Guid                CategoryId   { get; set; }
	public string              CategoryName { get; set; }
	public ICollection<string> Tags         { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<Note, NoteLookUpDto>()
			   .ForMember(dto => dto.CategoryName,
						  ops => ops.MapFrom(note => note.Category.Name));
	}
}
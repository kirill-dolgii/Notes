using AutoMapper;
using Notes.API.Application.Common.Mapping;
using Notes.API.Domain;

namespace Notes.API.Application.Notes.Queries.GetNoteDetailsQuery;

public class NoteDetailsVm : IMapWith<Note>
{
	public Guid                Id           { get; set; }
	public string              Title        { get; set; }
	public string              Description  { get; set; }
	public string            Category     { get; set; }
	public ICollection<string> Tags         { get; set; }
	public DateTime            CreationTime { get; set; }
	public DateTime?           EditionTime  { get; set; }
	public DateTime?           DeletionTime { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<NoteDetailsVm, Note>()
			   .ForMember(note => note.Category, ops => ops.MapFrom(vm => Enum.Parse<Domain.Category>(Category)))
			   .ReverseMap();
	}
}
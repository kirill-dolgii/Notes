using AutoMapper;
using Notes.API.Application.Common.Mapping;
using Notes.API.Domain;

namespace Notes.API.Application.Notes.Queries.GetNoteDetailsQuery;

public class NoteDetailsVm : IMapWith<Note>
{
	public Guid                Id           { get; set; }
	public string              Title        { get; set; }
	public string              Description  { get; set; }
	public Guid                CategoryId   { get; set; }
	public string              CategoryName { get; set; }
	public ICollection<string> Tags         { get; set; }
	public DateTime            CreationTime { get; set; }
	public DateTime?           EditionTime  { get; set; }
	public DateTime?           DeletionTime { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<Note, NoteDetailsVm>()
			   .ForMember(vm => vm.CategoryName, 
						  ops => ops.MapFrom(note => note.Category.Name));
	}
}
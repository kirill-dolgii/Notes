using Notes.API.Application.Common.Mapping;
using Notes.API.Domain;

namespace Notes.API.Application.Notes.Queries.GetNoteDetailsQuery;

public class NoteDetailsVm : IMapWith<Note>
{
	public Guid      Id           { get; set; }
	public string    Title        { get; set; }
	public string    Description  { get; set; }
	public DateTime  CreationTime { get; set; }
	public DateTime? EditionTime  { get; set; }
	public DateTime? DeletionTime { get; set; }
}
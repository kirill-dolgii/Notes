using System.ComponentModel.DataAnnotations.Schema;

namespace Notes.API.Domain;

public class Note
{
    public Guid                UserId       { get; set; }
    public Guid                Id           { get; set; }
    public string              Title        {get;  set; }
    public string              Description  { get; set; }
	public Guid                CategoryId   { get; set; }

    [ForeignKey("CategoryId")]
	public Category            Category     { get; set; }
	public ICollection<string> Tags         { get; set; }
    public DateTime            CreationTime { get; set; }
	public DateTime?           EditionTime  { get; set; }
	public DateTime?           DeletionTime { get; set; }
}
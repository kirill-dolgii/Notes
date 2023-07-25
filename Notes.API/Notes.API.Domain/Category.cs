namespace Notes.API.Domain;

public class Category
{
    public Guid UserId { get; set; }
    public Guid   Id     { get; set; }
	public string Name   { get; set; }
    public ICollection<Note> Notes { get; set; }
}
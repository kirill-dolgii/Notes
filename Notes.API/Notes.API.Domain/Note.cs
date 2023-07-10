namespace Notes.API.Domain;

public class Note
{
    public Guid      UserId       { get; }
    public Guid      Id           { get; }
    public string    Title        {get;  set; }
    public string    Description  { get; set; }
    public DateTime  CreationTime { get; }
	public DateTime? EditionTime  { get; set; }
    public DateTime? DeletionTime { get; set; }
}
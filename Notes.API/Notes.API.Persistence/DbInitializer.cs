namespace Notes.API.Persistence;

public class DbInitializer
{
	public static void Initialize(NotesDbContext dbContext)
	{
		dbContext.Database.EnsureCreated();
	}
}
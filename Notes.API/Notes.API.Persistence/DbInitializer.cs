namespace Notes.API.Persistence;

public static class DbInitializer
{
	public static void Initialize(NotesDbContext dbContext)
	{
		var created = dbContext.Database.EnsureCreated();
	}
}
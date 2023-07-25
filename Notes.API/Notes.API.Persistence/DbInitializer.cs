namespace Notes.API.Persistence;

public static class DbInitializer
{
	public static void Initialize(NotesDbContext dbContext)
	{
		//dbContext.Database.EnsureDeleted();
		dbContext.Database.EnsureCreated();
	}
}
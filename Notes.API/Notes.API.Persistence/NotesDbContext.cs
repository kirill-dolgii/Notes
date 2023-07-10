using Microsoft.EntityFrameworkCore;
using Notes.API.Application.Interfaces;
using Notes.API.Domain;
using Notes.API.Persistence.EntityTypeConfiguration;

namespace Notes.API.Persistence;

public sealed class NotesDbContext : DbContext, INotesDbContext
{
	public DbSet<Note> Notes { get; set; }
	public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options) {}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new NoteConfiguration());
		base.OnModelCreating(modelBuilder);
	}
}
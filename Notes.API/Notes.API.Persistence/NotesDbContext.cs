using Microsoft.EntityFrameworkCore;
using Notes.API.Application.Interfaces;
using Notes.API.Domain;
using Notes.API.Persistence.EntityTypeConfiguration;

namespace Notes.API.Persistence;

public sealed class NotesDbContext : DbContext, INotesDbContext
{
	public DbSet<Note>     Notes      { get; set; } = null!;
	public DbSet<Category> Categories { get; set; } = null!;
	public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options) {}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new NoteConfiguration());
		modelBuilder.ApplyConfiguration(new CategoryConfiguration());
		modelBuilder.Entity<Note>().HasOne(n => n.Category)
								   .WithMany(category => category.Notes)
								   .HasForeignKey(note => note.CategoryId);
		base.OnModelCreating(modelBuilder);
	}
}
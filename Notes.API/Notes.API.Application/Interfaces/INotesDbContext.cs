using Notes.API.Domain;
using Microsoft.EntityFrameworkCore;

namespace Notes.API.Application.Interfaces;

public interface INotesDbContext
{
    DbSet<Note>     Notes      { get; set; }
	DbSet<Category> Categories { get; set; }
	Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notes.API.Application.Interfaces;

namespace Notes.API.Persistence;

public static class DependencyInjection
{
	public static IServiceCollection AddPersistence(this IServiceCollection services, 
													IConfiguration configuration)
	{
		services.AddDbContext<NotesDbContext>(ops =>
		{
			ops.UseSqlServer(configuration.GetConnectionString("SalesDb"), 
							 opsBuilder =>
							 {
								 opsBuilder.MigrationsAssembly("Notes.API.WebAPI");
							 });
		});

		services.AddScoped<INotesDbContext>(provider => provider.GetService<NotesDbContext>()!);
		return services;
	}
}
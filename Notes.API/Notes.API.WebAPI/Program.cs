using Notes.API.Application.Common.Mapping;
using Notes.API.Application.Interfaces;
using Notes.API.Persistence;
using System.Reflection;
using Notes.API.Application;
using Notes.API.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(config =>
{
	config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
	config.AddProfile(new AssemblyMappingProfile(typeof(INotesDbContext).Assembly));
});

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(ops =>
{
	ops.AddPolicy("AllowAll", policyBuilder =>
	{
		policyBuilder.AllowAnyHeader();
		policyBuilder.AllowAnyMethod();
		policyBuilder.AllowAnyOrigin();
	});
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");


app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
});

using var scope = app.Services.CreateScope();

var serviceProvider = scope.ServiceProvider;
try
{
	var context = serviceProvider.GetRequiredService<NotesDbContext>();
	DbInitializer.Initialize(context);
	if (app.Environment.IsDevelopment())
	{
		var testCategories = new List<Category>
		{
			new()
			{
				Name = "Empty",
				Id = Guid.NewGuid(),
				UserId = Guid.Empty
			},
			new()
			{
				Name = "Work",
				Id = Guid.NewGuid(),
				UserId = Guid.Empty
			}
		};

		var testNotes = new List<Note>
		{
			new()
			{
				UserId = Guid.Empty,
				Id = Guid.NewGuid(),
				Title = "Work Note",
				Description = "-",
				Category = testCategories[1],
				CategoryId = testCategories[1].Id,
				Tags = new List<string>(),
				CreationTime = DateTime.Now
			},
			new()
			{
				UserId = Guid.Empty,
				Id = Guid.NewGuid(),
				Title = "Empty Note",
				Description = "-",
				Category = testCategories[0],
				CategoryId = testCategories[0].Id,
				Tags = new List<string>(),
				CreationTime = DateTime.Now
			}
		};

		await context.Notes.AddRangeAsync(testNotes);
		await context.Categories.AddRangeAsync(testCategories);

		await context.SaveChangesAsync();
    }
}
catch (Exception ex)
{
	// ignored
}

app.Run();

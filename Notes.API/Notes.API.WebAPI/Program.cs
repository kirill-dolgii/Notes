using Notes.API.Application.Common.Mapping;
using Notes.API.Application.Interfaces;
using Notes.API.Persistence;
using System.Reflection;
using Notes.API.Application;

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
}
catch (Exception ex)
{
	// ignored
}

app.MapGet("/", () => "Hello World!");

app.Run();

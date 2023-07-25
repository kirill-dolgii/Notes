using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;
using Notes.API.Domain;

namespace Notes.API.Persistence.EntityTypeConfiguration
{
    internal class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
		public void Configure(EntityTypeBuilder<Note> builder)
		{
			builder.HasKey(note => note.Id);
			builder.HasIndex(note => note.Id).IsUnique();
			builder.Property(note => note.Title).HasMaxLength(255);
			builder.Property(note => note.Description).HasMaxLength(5000);
			builder.Property(note => note.Tags)
				   .HasConversion(tags => string.Join(";", tags), 
								  str => str.IsNullOrEmpty() 
									  ? new() 
									  : str.Split(";", StringSplitOptions.None).ToList());
		}
	}
}

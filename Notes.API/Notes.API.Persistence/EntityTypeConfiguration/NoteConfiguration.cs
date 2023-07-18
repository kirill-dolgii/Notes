using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
			builder.Property(note => note.Category).HasConversion(c => c.ToString(), str => Enum.Parse<Category>(str));
			builder.Property(note => note.Tags).HasConversion(tags => string.Join(";", tags), str => str.Split(";", StringSplitOptions.None).ToList());
		}
	}
}

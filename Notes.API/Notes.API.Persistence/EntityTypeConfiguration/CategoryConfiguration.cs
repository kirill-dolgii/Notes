﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.API.Domain;

namespace Notes.API.Persistence.EntityTypeConfiguration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
	public void Configure(EntityTypeBuilder<Category> builder)
	{
		builder.HasKey(category => category.Id);
		builder.HasIndex(category => category.Id).IsUnique();
		builder.Property(category => category.Name).HasMaxLength(255);
	}
}

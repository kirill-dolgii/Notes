using AutoMapper;
using Notes.API.Application.Common.Mapping;
using Notes.API.Domain;

namespace Notes.API.Application.Categories.Queries.GetCategoryListQuery;

public class CategoryLookUpDto : IMapWith<Category>
{
	public Guid                Id           { get; set; }
    public string              Name         { get; set; }

    public void Mapping(Profile profile)
	{
		profile.CreateMap<Category, CategoryLookUpDto>();
	}
}
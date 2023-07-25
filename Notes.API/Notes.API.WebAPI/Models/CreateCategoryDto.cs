using AutoMapper;
using Notes.API.Application.Categories.Commands.CreateCategoryCommand;
using Notes.API.Application.Common.Mapping;

namespace Notes.API.WebAPI.Models;

public class CreateCategoryDto : IMapWith<CreateCategoryCommand>
{
    public string Name { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<CreateCategoryDto, CreateCategoryCommand>();
	}
}
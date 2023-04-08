using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Commands.UpdateCategory;
using Application.Features.Categories.Queries.GetCategoriesList;
using Application.Features.Categories.Queries.GetCategoriesListWithIdeas;
using Application.Features.Ideas;
using Application.Features.Ideas.Commands.CreateIdea;
using Application.Features.Ideas.Commands.DeleteIdea;
using Application.Features.Ideas.Commands.UpdateIdea;
using Application.Features.Ideas.Queries.GetIdeaDetail;
using Application.Features.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles
{
    public class MappingProfile : Profile
	{
        public MappingProfile()
        {
            CreateMap<Idea, UpdateIdeaCommand>().ReverseMap();
            CreateMap<Idea, DeleteIdeaCommand>().ReverseMap();
            CreateMap<Idea, GetIdeaDetailQuery>().ReverseMap();
            //CreateMap<Idea, GetIdeasListQuery>().ReverseMap();

            CreateMap<Idea, CategoryIdeaDto>().ReverseMap();
            CreateMap<Idea, IdeaDetailViewModel>().ReverseMap();
			CreateMap<Idea, IdeaListViewModel>().ReverseMap();
			CreateMap<Idea, CreateIdeaCommand>().ReverseMap().ReverseMap();

			CreateMap<Category, IdeaListViewModel>().ReverseMap();
            CreateMap<Category, IdeaDetailViewModel>().ReverseMap();

			CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListViewModel>();
			CreateMap<Category, CategoryIdeaListViewModel>();
			CreateMap<Category, CreateCategoryCommand>();
			CreateMap<Category, CreateCategoryDto>();

			CreateMap<Category, UpdateCategoryDto>().ReverseMap();

			//CreateMap<Category, CreateIdeaCommand>().ReverseMap();
			//         CreateMap<Category, UpdateIdeaCommand>().ReverseMap();
			//         CreateMap<Category, DeleteIdeaCommand>().ReverseMap();
		}
	}
}

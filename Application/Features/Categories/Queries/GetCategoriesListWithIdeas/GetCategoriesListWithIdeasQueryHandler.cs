using Application.Contracts.Persistence;
using Application.Features.Categories.Queries.GetCategoriesList;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries.GetCategoriesListWithIdeas
{
	public class GetCategoriesListWithIdeasQueryHandler : IRequestHandler<GetCategoriesListWithIdeasQuery, List<CategoryIdeaListViewModel>>
	{
		private readonly IMapper _mapper;
		private readonly ICategoryRepository _categoryRepository;

		public GetCategoriesListWithIdeasQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
		{
			_mapper = mapper;
			_categoryRepository = categoryRepository;
		}

		public async Task<List<CategoryIdeaListViewModel>> Handle(GetCategoriesListWithIdeasQuery request, CancellationToken cancellationToken)
		{
			var list = await _categoryRepository.GetAllCategoriesWithIdeas();
			
			return _mapper.Map<List<CategoryIdeaListViewModel>>(list);
		}
	}
}

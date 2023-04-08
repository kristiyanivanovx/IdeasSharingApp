using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries.GetCategoriesList
{
	public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, List<CategoryListViewModel>>
	{
		private readonly IMapper _mapper;
		private readonly IAsyncRepository<Category> _categoryRepository;

		public GetCategoriesListQueryHandler(IMapper mapper, IAsyncRepository<Category> categoryRepository)
		{
			_mapper = mapper;
			_categoryRepository = categoryRepository;
		}

		public async Task<List<CategoryListViewModel>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
		{
			var allCategories = (await _categoryRepository.GetListAllAsync())
				.OrderBy(x => x.Name);

			return _mapper.Map<List<CategoryListViewModel>>(allCategories);
		}
	}
}

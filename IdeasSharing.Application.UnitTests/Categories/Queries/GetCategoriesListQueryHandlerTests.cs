using Application.Contracts.Persistence;
using Application.Features.Categories.Queries.GetCategoriesList;
using Application.Profiles;
using AutoMapper;
using Domain.Entities;
using IdeasSharing.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IdeasSharing.Application.UnitTests.Categories.Queries
{
	public class GetCategoriesListQueryHandlerTests
	{
		private readonly IMapper _mapper;
		private readonly Mock<ICategoryRepository> _mockCategoryRepository;

		public GetCategoriesListQueryHandlerTests()
		{
			_mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
			var configurationProvider = new MapperConfiguration(config =>
			{
				config.AddProfile<MappingProfile>();
			});

			_mapper = configurationProvider.CreateMapper();
		}

		[Fact]
		public async Task Handle_GetAllCategoriesList()
		{
			var handler = new GetCategoriesListQueryHandler(_mapper, _mockCategoryRepository.Object);

			var result = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);

			result.ShouldBeOfType<List<CategoryListViewModel>>();

			result.Count.ShouldBe(4);
		}
	}
}

using Application.Contracts.Persistence;
using Application.Features.Categories.Queries.GetCategoriesList;
using Application.Features.Categories.Queries.GetCategoriesListWithIdeas;
using Application.Profiles;
using AutoMapper;
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
	public class GetCategoriesListWithIdeasQueryHandlerTests
	{
		private readonly IMapper _mapper;
		private readonly Mock<ICategoryRepository> _mockCategoryRepository;

		public GetCategoriesListWithIdeasQueryHandlerTests()
		{
			_mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
			var configurationProvider = new MapperConfiguration(config =>
			{
				config.AddProfile<MappingProfile>();
			});

			_mapper = configurationProvider.CreateMapper();
		}

		[Fact]
		public async Task Handler_GetCategoriesListWithIdeas()
		{
			var handler = new GetCategoriesListWithIdeasQueryHandler(_mapper, _mockCategoryRepository.Object);

			var result = await handler.Handle(new GetCategoriesListWithIdeasQuery(), CancellationToken.None);

			result.ShouldBeOfType<List<CategoryIdeaListViewModel>>();

			result.Count.ShouldBe(4);
			result.First().Ideas.ShouldNotBeNull();
			result.First().Ideas.ShouldBeEmpty();
		}
	}
}

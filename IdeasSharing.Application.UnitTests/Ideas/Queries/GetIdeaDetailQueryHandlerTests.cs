using Application.Contracts.Persistence;
using Application.Features.Ideas;
using Application.Features.Ideas.Queries.GetIdeaDetail;
using Application.Features.Queries;
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

namespace IdeasSharing.Application.UnitTests.Ideas.Queries
{
	public class GetIdeaDetailQueryHandlerTests
	{
		private readonly IMapper _mapper;
		private readonly Mock<IIdeaRepository> _mockIdeaRepository;
		private readonly Mock<ICategoryRepository> _mockCategoryRepository;

		public GetIdeaDetailQueryHandlerTests()
		{
			_mockIdeaRepository = RepositoryMocks.GetIdeaRepository();
			_mockCategoryRepository = RepositoryMocks.GetCategoryRepository();

			var configurationProvider = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<MappingProfile>();
			});

			_mapper = configurationProvider.CreateMapper();
		}

		[Fact]
		public async Task Handle_GetIdeaDetail()
		{
			// Arrange
			var handler = new GetIdeaDetailQueryHandler(_mapper, _mockIdeaRepository.Object, _mockCategoryRepository.Object);

			var developmentAppIdeaGuid = Guid.Parse("{489c3a8c-915a-44e4-8eb1-3877d21f6d7e}");

			var productivityCategoryGuid = Guid.Parse("{0d5ab172-1060-4e6b-ba34-435416754b9f}");

			// Act
			var result = await handler.Handle(new GetIdeaDetailQuery() { Id = developmentAppIdeaGuid }, CancellationToken.None);

			// Assert
			result.Name.ShouldBe("Create an app using AI to help developers with programming.");
			result.Category.CategoryId.ShouldBe(productivityCategoryGuid);
		}
	}
}

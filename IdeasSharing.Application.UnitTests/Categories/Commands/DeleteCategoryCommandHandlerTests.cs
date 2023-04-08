using Application.Contracts.Persistence;
using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Commands.DeleteCategory;
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

namespace IdeasSharing.Application.UnitTests.Categories.Commands
{
	public class DeleteCategoryCommandHandlerTests
	{
		private readonly IMapper _mapper;
		private readonly Mock<ICategoryRepository> _mockCategoryRepository;

		public DeleteCategoryCommandHandlerTests()
		{
			_mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
			var configurationProvider = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<MappingProfile>();
			});

			_mapper = configurationProvider.CreateMapper();
		}

		[Fact]
		public async Task Handle_ValidCategory_RemovedFromCategoriesRepository()
		{
			// Arrange
			var handler = new DeleteCategoryCommandHandler(_mapper, _mockCategoryRepository.Object);

			var productivityGuid = Guid.Parse("{0d5ab172-1060-4e6b-ba34-435416754b9f}");

			// Act
			await handler.Handle(new DeleteCategoryCommand() { CategoryId = productivityGuid }, CancellationToken.None);

			var allCategories = await _mockCategoryRepository.Object.GetListAllAsync();

			// Assert
			allCategories.Count.ShouldBe(3);
		}
	}
}

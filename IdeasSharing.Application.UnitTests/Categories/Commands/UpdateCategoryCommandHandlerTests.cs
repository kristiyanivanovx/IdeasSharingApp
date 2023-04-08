using Application.Contracts.Persistence;
using Application.Features.Categories.Commands.DeleteCategory;
using Application.Features.Categories.Commands.UpdateCategory;
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
	public class UpdateCategoryCommandHandlerTests
	{
		private readonly IMapper _mapper;
		private readonly Mock<ICategoryRepository> _mockCategoryRepository;

		public UpdateCategoryCommandHandlerTests()
		{
			_mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
			var configurationProvider = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<MappingProfile>();
			});

			_mapper = configurationProvider.CreateMapper();
		}

		[Fact]
		public async Task Handle_ValidCategory_UpdatedFromCategoriesRepository()
		{
			// Arrange
			var handler = new UpdateCategoryCommandHandler(_mapper, _mockCategoryRepository.Object);

			var productivityGuid = Guid.Parse("{0d5ab172-1060-4e6b-ba34-435416754b9f}");

			var updatedCategoryName = "Not productivity";

			// Act
			await handler.Handle(new UpdateCategoryCommand() { CategoryId = productivityGuid, Name = updatedCategoryName }, CancellationToken.None);

			var category = await _mockCategoryRepository.Object.GetByIdAsync(productivityGuid);

			// Assert
			category.Name.ShouldBe(updatedCategoryName);
		}
	}
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Persistence;
using Shouldly;
using Xunit;

namespace IdeasSharingDbContextTests
{
	public class IdeasSharingDbContextTests
	{
		private readonly IdeasSharingDbContext _ideasSharingDbContext;

		public IdeasSharingDbContextTests()
		{
			var dbContextOptions = new DbContextOptionsBuilder<IdeasSharingDbContext>()
				.UseInMemoryDatabase(Guid.NewGuid().ToString())
				.Options;

			_ideasSharingDbContext = new IdeasSharingDbContext(dbContextOptions);
		}

		[Fact]
		public async void Save_Category()
		{
			// Arrange
			var categoryToCreate = new Category() { CategoryId = Guid.NewGuid(), Name = "Test category" };

			// Act
			_ideasSharingDbContext.Categories.Add(categoryToCreate);
			
			await _ideasSharingDbContext.SaveChangesAsync();

			var categoryRetrieved = await _ideasSharingDbContext.Categories.FirstOrDefaultAsync(x => x.Name == "Test category");

			// Assert
			categoryRetrieved.ShouldNotBeNull();
		}
	}
}
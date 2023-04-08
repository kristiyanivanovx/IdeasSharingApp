using Domain.Entities;
using Persistence;

namespace IdeasSharing.API.IntegrationTests.Base
{
    public class Utilities
    {
		public static void InitializeDbForTests(IdeasSharingDbContext context)
		{
			var productivityGuid = Guid.Parse("{0d5ab172-1060-4e6b-ba34-435416754b9f}");
			var sportsGuid = Guid.Parse("{f50f6ae0-ea8d-47b8-8fb9-82aa46fdc61e}");
			var medicineGuid = Guid.Parse("{c3c04a66-6017-413d-8376-9307a9cf83fd}");
			var financeGuid = Guid.Parse("{9095f861-9771-40d8-b761-9d9210ca7a26}");

			var categories = new List<Category>
			{
				new Category
				{
					CategoryId = productivityGuid,
					Name = "Productivity"
				},
				new Category
				{
					CategoryId = sportsGuid,
					Name = "Sports"
				},
				new Category
				{
					CategoryId = financeGuid,
					Name = "Finance"
				},
				 new Category
				{
					CategoryId = medicineGuid,
					Name = "Medicine"
				}
			};

			context.Categories.AddRange(categories);
			context.SaveChanges();
		}
	}
}
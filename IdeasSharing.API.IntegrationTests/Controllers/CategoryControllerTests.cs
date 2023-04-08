using IdeasSharing.API.IntegrationTests.Base;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Text.Json;
using Application.Features.Categories.Queries.GetCategoriesList;

namespace IdeasSharing.API.IntegrationTests.Controllers
{
	public class CategoryControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
	{
		private readonly CustomWebApplicationFactory<Program> _factory;

		public CategoryControllerTests(CustomWebApplicationFactory<Program> factory)
		{
			_factory = factory;
		}

		// todo: fix this is it fails
		//[Fact]
		public async Task ReturnsSuccessResult()
		{
			var client = _factory.GetAnonymousClient();

			var response = await client.GetAsync("/api/category/all");

			response.EnsureSuccessStatusCode();

			var responseString = await response.Content.ReadAsStringAsync();

			var result = JsonSerializer.Deserialize<List<CategoryListViewModel>>(responseString);

			Assert.IsType<List<CategoryListViewModel>>(result);
			Assert.NotEmpty(result);
		}
	}
}

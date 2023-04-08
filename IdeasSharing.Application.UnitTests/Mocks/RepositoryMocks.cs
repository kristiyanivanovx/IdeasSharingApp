using Application.Contracts.Persistence;
using Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IdeasSharing.Application.UnitTests.Mocks
{
	public class RepositoryMocks
	{
		public static Mock<ICategoryRepository> GetCategoryRepository()
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

			var categoriesWithIdeas = new List<Category>
			{
				new Category
				{
					CategoryId = productivityGuid,
					Name = "Productivity",
					Ideas = new List<Idea>(),
				},
				new Category
				{
					CategoryId = sportsGuid,
					Name = "Sports",
					Ideas = new List<Idea>(),
				},
				new Category
				{
					CategoryId = financeGuid,
					Name = "Finance",
					Ideas = new List<Idea>(),
				},
				new Category
				{
					CategoryId = medicineGuid,
					Name = "Medicine",
					Ideas = new List<Idea>(),
				}
			};

			var mockCategoryRepository = new Mock<ICategoryRepository>();

			mockCategoryRepository
				.Setup(repo => repo.GetListAllAsync())
				.ReturnsAsync(categories);

			mockCategoryRepository
				.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
				.ReturnsAsync((Guid id) =>
					{
						return categories.First(x => x.CategoryId == id);
					});

			mockCategoryRepository
				.Setup(repo => repo.AddAsync(It.IsAny<Category>()))
				.ReturnsAsync((Category category) =>
					{
						categories.Add(category);
						return category;
					});

			mockCategoryRepository
				.Setup(repo => repo.UpdateAsync(It.IsAny<Category>()))
				.Returns((Category category) =>
				{
					var repoCategory = categories.FirstOrDefault(x => x.CategoryId == category.CategoryId);
					if (repoCategory != null)
					{
						repoCategory.Name = category.Name;
					}

					return Task.CompletedTask;
				});

			mockCategoryRepository
				.Setup(repo => repo.DeleteAsync(It.IsAny<Category>()))
				.Returns((Category category) =>
				{
					categories.Remove(category);
					return Task.CompletedTask;
				});

			mockCategoryRepository
				.Setup(repo => repo.GetAllCategoriesWithIdeas())
				.ReturnsAsync(categoriesWithIdeas);

			return mockCategoryRepository;
		}

		public static Mock<IIdeaRepository> GetIdeaRepository()
		{
			var productivityCategoryGuid = Guid.Parse("{0d5ab172-1060-4e6b-ba34-435416754b9f}");
			var medicineCategoryGuid = Guid.Parse("{c3c04a66-6017-413d-8376-9307a9cf83fd}");

			var developmentAppGuid = Guid.Parse("{489c3a8c-915a-44e4-8eb1-3877d21f6d7e}");
			var medicineAppGuid = Guid.Parse("{d62c02f5-7c3f-481d-8ae4-230a38f0edb3}");

			var ideas = new List<Idea>
			{
				new Idea
				{
					IdeaId = developmentAppGuid,
					Name = "Create an app using AI to help developers with programming.",
					Description = "Test Description 1",
					CategoryId = productivityCategoryGuid,
				},
				new Idea
				{
					IdeaId = medicineAppGuid,
					Name = "Create an app using AI to help detect health issues early.",
					Description = "Test Description 2",
					CategoryId = medicineCategoryGuid,
				},
			};

			var mockIdeaRepository = new Mock<IIdeaRepository>();

			mockIdeaRepository
				.Setup(repo => repo.GetListAllAsync())
				.ReturnsAsync(ideas);

			mockIdeaRepository
				.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
				.ReturnsAsync((Guid id) =>
				{
					return ideas.First(x => x.IdeaId == id);
				});

			mockIdeaRepository
				.Setup(repo => repo.AddAsync(It.IsAny<Idea>()))
				.ReturnsAsync((Idea idea) =>
				{
					ideas.Add(idea);
					return idea;
				});

			mockIdeaRepository
				.Setup(repo => repo.DeleteAsync(It.IsAny<Idea>()))
				.Returns((Idea idea) =>
				{
					ideas.Remove(idea);
					return Task.CompletedTask;
				});

			mockIdeaRepository
				.Setup(repo => repo.UpdateAsync(It.IsAny<Idea>()))
				.Returns((Idea idea) =>
				{
					var repoIdea = ideas.FirstOrDefault(x => x.IdeaId == idea.IdeaId);
					if (repoIdea != null)
					{
						repoIdea.Name = idea.Name;

						if (idea.Description != null)
						{
							repoIdea.Description = idea.Description;
						}
					}

					return Task.CompletedTask;
				});

			return mockIdeaRepository;
		}
	}
}
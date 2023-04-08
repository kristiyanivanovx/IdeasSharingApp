using App.Services.Base;
using App.ViewModels;
using IdeasSharing.App.Services;

namespace App.Contracts
{
	public interface ICategoryDataService
	{
		Task<List<CategoryViewModel>> GetAllCategories();

		Task<List<CategoryIdeasViewModel>> GetAllCategoriesWithIdeas();

		//Task<ApiResponse<CategoryDto>> CreateCategory(CategoryViewModel categoryViewModel);
	}
}

using App.Contracts;
using App.Services.Base;
using App.ViewModels;
using AutoMapper;
using Blazored.LocalStorage;
using IdeasSharing.App.Services;

namespace App.Services
{
	//public class CategoryDataService : BaseDataService, ICategoryDataService
	//{
	//	private readonly IMapper _mapper;

	//	public CategoryDataService(IdeasSharing.App.Services.IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
	//	{
	//		_mapper = mapper;
	//	}

	//	public async Task<List<CategoryViewModel>> GetAllCategories()
	//	{
	//		await AddBearerToken();

	//		var allCategories = await _client.GetAllCategoriesAsync();
	//		var mappedCategories = _mapper.Map<ICollection<CategoryViewModel>>(allCategories);
	//		return mappedCategories.ToList();
	//	}

	//	public async Task<List<CategoryIdeasViewModel>> GetAllCategoriesWithIdeas(bool includeHistory)
	//	{
	//		await AddBearerToken();

	//		var allCategories = await _client.GetCategoriesWithIdeasAsync(includeHistory);
	//		var mappedCategories = _mapper.Map<ICollection<CategoryIdeasViewModel>>(allCategories);
	//		return mappedCategories.ToList();

	//	}

	//	public async Task<ApiResponse<CategoryDto>> CreateCategory(CategoryViewModel categoryViewModel)
	//	{
	//		try
	//		{
	//			ApiResponse<CategoryDto> apiResponse = new ApiResponse<CategoryDto>();
	//			CreateCategoryCommand createCategoryCommand = _mapper.Map<CreateCategoryCommand>(categoryViewModel);
	//			var createCategoryCommandResponse = await _client.AddCategoryAsync(createCategoryCommand);
	//			if (createCategoryCommandResponse.Success)
	//			{
	//				apiResponse.Data = _mapper.Map<CategoryDto>(createCategoryCommandResponse.Category);
	//				apiResponse.Success = true;
	//			}
	//			else
	//			{
	//				apiResponse.Data = null;
	//				foreach (var error in createCategoryCommandResponse.ValidationErrors)
	//				{
	//					apiResponse.ValidationErrors += error + Environment.NewLine;
	//				}
	//			}
	//			return apiResponse;
	//		}
	//		catch (ApiException ex)
	//		{
	//			return ConvertApiExceptions<CategoryDto>(ex);
	//		}
	//	}
	//}
}

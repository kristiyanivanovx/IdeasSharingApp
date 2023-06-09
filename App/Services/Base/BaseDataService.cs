﻿using Blazored.LocalStorage;
using IdeasSharing.App.Services;
using System.Net.Http.Headers;

namespace App.Services.Base
{
	public class BaseDataService
	{
		protected readonly ILocalStorageService _localStorage;

		protected IdeasSharing.App.Services.IClient _client;

		public BaseDataService(IdeasSharing.App.Services.IClient client, ILocalStorageService localStorage)
		{
			_client = client;
			_localStorage = localStorage;
		}

		protected ApiResponse<Guid> ConvertApiExceptions<Guid>(ApiException ex)
		{
			if (ex.StatusCode == 400)
			{
				return new ApiResponse<Guid>() { Message = "Validation errors have occured.", ValidationErrors = ex.Response, Success = false };
			}
			else if (ex.StatusCode == 404)
			{
				return new ApiResponse<Guid>() { Message = "The requested item could not be found.", Success = false };
			}
			else
			{
				return new ApiResponse<Guid>() { Message = "Something went wrong, please try again.", Success = false };
			}
		}

		//protected async Task AddBearerToken()
		//{
		//	if (await _localStorage.ContainKeyAsync("token"))
		//	{
		//		_client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _localStorage.GetItemAsync<string>("token"));
		//	}
		//}
	}
}

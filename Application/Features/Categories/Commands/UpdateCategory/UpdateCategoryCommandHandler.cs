using Application.Contracts.Persistence;
using Application.Features.Categories.Commands.CreateCategory;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.UpdateCategory
{
	public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryCommandResponse>
	{
		private readonly IMapper _mapper;
		private readonly ICategoryRepository _categoryRepository;

		public UpdateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
		{
			_mapper = mapper;
			_categoryRepository = categoryRepository;
		}

		public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
		{
			var updateCategoryCommandResponse = new UpdateCategoryCommandResponse();

			var validator = new UpdateCategoryCommandValidator();
			var validationResult = await validator.ValidateAsync(request);

			if (validationResult.Errors.Count > 0)
			{
				updateCategoryCommandResponse.Success = false;
				updateCategoryCommandResponse.ValidationErrors = new List<string>();
				foreach (var error in validationResult.Errors)
				{
					updateCategoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
				}
			}

			if (updateCategoryCommandResponse.Success)
			{
				var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
				
				category.Name = request.Name;

				await _categoryRepository.UpdateAsync(category);
				
				updateCategoryCommandResponse.Category = _mapper.Map<UpdateCategoryDto>(category);
			}

			return updateCategoryCommandResponse;
		}
	}
}

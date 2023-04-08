using Application.Contracts.Persistence;
using Application.Features.Ideas.Commands.CreateIdea;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.CreateCategory
{
	public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
	{
		private readonly IMapper _mapper;
		private readonly ICategoryRepository _categoryRepository;

		public CreateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
		{
			_mapper = mapper;
			_categoryRepository = categoryRepository;
		}

		public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
		{
			var createCategoryCommandResponse = new CreateCategoryCommandResponse();

			var validator = new CreateCategoryCommandValidator();
			var validationResult = await validator.ValidateAsync(request);

			if (validationResult.Errors.Count > 0)
			{
				createCategoryCommandResponse.Success = false;
				createCategoryCommandResponse.ValidationErrors = new List<string>();
				foreach (var error in validationResult.Errors)
				{
					createCategoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
				}
			}

			if (createCategoryCommandResponse.Success)
			{
				var category = new Category() { Name = request.Name };
				category = await _categoryRepository.AddAsync(category);
				createCategoryCommandResponse.Category = _mapper.Map<CreateCategoryDto>(category);
			}

			return createCategoryCommandResponse;
		}
	}
}

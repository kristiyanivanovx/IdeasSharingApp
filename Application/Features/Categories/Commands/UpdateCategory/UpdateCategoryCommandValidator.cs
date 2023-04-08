using Application.Contracts.Persistence;
using Application.Features.Categories.Commands.UpdateCategory;
using Application.Features.Ideas.Commands.CreateIdea;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.CreateCategory
{
	public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
	{
		public UpdateCategoryCommandValidator()
        {
			RuleFor(p => p.CategoryId)
				.NotEmpty()
					.WithMessage("{PropertyName} is required.");

			RuleFor(p => p.Name)
				.NotEmpty()
					.WithMessage("{PropertyName} is required.")
				.NotNull()
				.MaximumLength(50)
					.WithMessage("{PropertyName} must not exceed 50 characters.");
		}
    }
}

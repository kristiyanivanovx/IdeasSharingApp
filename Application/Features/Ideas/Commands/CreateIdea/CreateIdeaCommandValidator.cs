using Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ideas.Commands.CreateIdea
{
	public class CreateIdeaCommandValidator : AbstractValidator<CreateIdeaCommand>
	{
		private readonly IIdeaRepository _ideaRepository;

        public CreateIdeaCommandValidator(IIdeaRepository ideaRepository)
        {
			_ideaRepository = ideaRepository;

            RuleFor(p => p.Name)
				.NotEmpty()
					.WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50)
					.WithMessage("{PropertyName} must not exceed 50 characters.");

			RuleFor(p => p.CreatedDate)
				.NotEmpty()
					.WithMessage("{PropertyName} is required.")
				.NotNull();

			RuleFor(p => p)
				.MustAsync(IsIdeaNameAndDescriptionUnique)
				.WithMessage("An idea with the same name and description already exists!");
		}

		private async Task<bool> IsIdeaNameAndDescriptionUnique(CreateIdeaCommand command, CancellationToken cancellationToken)
		{
			return !(await _ideaRepository.IsIdeaNameAndDescriptionUnique(command.Name, command.Description));
		} 
    }
}

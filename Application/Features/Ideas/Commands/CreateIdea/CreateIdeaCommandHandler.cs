using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ideas.Commands.CreateIdea
{
	public class CreateIdeaCommandHandler : IRequestHandler<CreateIdeaCommand, Guid>
	{
		private readonly IMapper _mapper;
		private readonly IIdeaRepository _ideaRepository;

		public CreateIdeaCommandHandler(IMapper mapper, IIdeaRepository ideaRepository)
		{
			_mapper = mapper;
			_ideaRepository = ideaRepository;
		}

		public async Task<Guid> Handle(CreateIdeaCommand request, CancellationToken cancellationToken)
		{
			var idea = _mapper.Map<Idea>(request);

			var validator = new CreateIdeaCommandValidator(_ideaRepository);
			var validationResult = await validator.ValidateAsync(request);
			if (validationResult.Errors.Count > 0) 
			{
				throw new Exceptions.ValidationException(validationResult);
			}

			idea = await _ideaRepository.AddAsync(idea);

			return idea.IdeaId;
		}
	}
}

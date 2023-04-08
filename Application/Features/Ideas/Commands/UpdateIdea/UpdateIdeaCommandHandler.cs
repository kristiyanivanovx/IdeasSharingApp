using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ideas.Commands.UpdateIdea
{
	public class UpdateIdeaCommandHandler : IRequestHandler<UpdateIdeaCommand>
	{
		private readonly IMapper _mapper;
		private readonly IAsyncRepository<Idea> _ideaRepository;

		public UpdateIdeaCommandHandler(IMapper mapper, IAsyncRepository<Idea> ideaRepository)
		{
			_mapper = mapper;
			_ideaRepository = ideaRepository;
		}

		public async Task<Unit> Handle(UpdateIdeaCommand request, CancellationToken cancellationToken)
		{
			var ideaToUpdate = await _ideaRepository.GetByIdAsync(request.IdeaId) ?? throw new NotFoundException(nameof(Idea), request.IdeaId);

			_mapper.Map(request, ideaToUpdate, typeof(UpdateIdeaCommand), typeof(Idea));

			await _ideaRepository.UpdateAsync(ideaToUpdate);

			return Unit.Value;
		}
	}
}

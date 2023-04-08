using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ideas.Commands.DeleteIdea
{
	public class DeleteIdeaCommandHandler : IRequestHandler<DeleteIdeaCommand>
	{
		private readonly IMapper _mapper;
		private readonly IAsyncRepository<Idea> _ideaRepository;

		public DeleteIdeaCommandHandler(IMapper mapper, IAsyncRepository<Idea> ideaRepository)
		{
			_mapper = mapper;
			_ideaRepository = ideaRepository;
		}

		public async Task<Unit> Handle(DeleteIdeaCommand request, CancellationToken cancellationToken)
		{
			var ideaToDelete = await _ideaRepository.GetByIdAsync(request.IdeaId);

			await _ideaRepository.DeleteAsync(ideaToDelete);

			return Unit.Value;
		}
	}
}

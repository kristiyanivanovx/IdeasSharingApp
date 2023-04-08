using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Ideas;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Ideas
{
	public class GetIdeasListQueryHandler : IRequestHandler<GetIdeasListQuery, List<IdeaListViewModel>>
	{
		private readonly IAsyncRepository<Idea> _ideaRepository;
		private readonly IMapper _mapper;

        public GetIdeasListQueryHandler(IMapper mapper, IAsyncRepository<Idea> ideaRepository)
        {
			_mapper = mapper;
			_ideaRepository = ideaRepository;
        }

        public async Task<List<IdeaListViewModel>> Handle(GetIdeasListQuery request, CancellationToken cancellationToken)
		{
			var allIdeas = (await _ideaRepository.GetListAllAsync())
				.OrderBy(x => x.CreatedDate);

			return _mapper.Map<List<IdeaListViewModel>>(allIdeas);
		}
	}
}

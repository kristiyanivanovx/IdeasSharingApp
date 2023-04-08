using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using Application.Features.Ideas.Queries.GetIdeaDetail;

namespace Application.Features.Queries
{
    public class GetIdeaDetailQueryHandler : IRequestHandler<GetIdeaDetailQuery, IdeaDetailViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Idea> _ideaRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;

        public GetIdeaDetailQueryHandler(
            IMapper mapper,
            IAsyncRepository<Idea> ideaRepository,
            IAsyncRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _ideaRepository = ideaRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IdeaDetailViewModel> Handle(GetIdeaDetailQuery request, CancellationToken cancellationToken)
        {
            var idea = await _ideaRepository.GetByIdAsync(request.Id);
            var ideaDetailDto = _mapper.Map<IdeaDetailViewModel>(idea);

            var category = await _categoryRepository.GetByIdAsync(idea.CategoryId);
            ideaDetailDto.Category = _mapper.Map<CategoryDto>(category);

            return ideaDetailDto;
        }
    }
}

using Application.Features.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ideas.Queries.GetIdeaDetail
{
    public class GetIdeaDetailQuery : IRequest<IdeaDetailViewModel>
    {
        public Guid Id { get; set; }
    }
}

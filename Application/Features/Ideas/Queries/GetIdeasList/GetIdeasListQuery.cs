using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Ideas;

namespace Application.Features.Ideas
{
	public class GetIdeasListQuery : IRequest<List<IdeaListViewModel>>
	{
	}
}

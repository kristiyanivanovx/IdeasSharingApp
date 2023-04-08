using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ideas.Commands.DeleteIdea
{
	public class DeleteIdeaCommand : IRequest
	{
        public Guid IdeaId { get; set; }
    }
}

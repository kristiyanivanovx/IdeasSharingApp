using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ideas.Commands.UpdateIdea
{
	public class UpdateIdeaCommand : IRequest
	{
		public Guid IdeaId { get; set; }

		public string Name { get; set; } = string.Empty;

		public string? Description { get; set; }

		public DateTime CreatedDate { get; set; }

		public Guid CategoryId { get; set; }
	}
}

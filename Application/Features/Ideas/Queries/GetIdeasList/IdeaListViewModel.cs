using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ideas
{
	public class IdeaListViewModel
	{
		public Guid IdeaId { get; set; }

		public string Name { get; set; } = string.Empty;

		public string? Description { get; set; }

		// details provided in other search
		//public Guid CategoryId { get; set; }

		//public Category Category { get; set; } = default!;

		public DateTime CreatedDate { get; set; }
	}
}

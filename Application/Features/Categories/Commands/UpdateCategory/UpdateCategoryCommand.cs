using Application.Features.Categories.Commands.CreateCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.UpdateCategory
{
	public class UpdateCategoryCommand : IRequest<UpdateCategoryCommandResponse>
	{
		public Guid CategoryId { get; set; }

		public string Name { get; set; } = string.Empty;
	}
}

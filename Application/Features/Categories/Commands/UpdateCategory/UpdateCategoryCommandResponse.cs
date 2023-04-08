using Application.Features.Categories.Commands.CreateCategory;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.UpdateCategory
{
	public class UpdateCategoryCommandResponse : BaseResponse
	{
		public UpdateCategoryCommandResponse() : base()
		{

		}

		public UpdateCategoryDto Category { get; set; } = default!;
	}
}

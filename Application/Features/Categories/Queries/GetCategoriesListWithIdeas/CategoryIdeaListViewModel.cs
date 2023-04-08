using Application.Features.Categories.Queries.GetCategoriesListWithIdeas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries.GetCategoriesList
{
	public class CategoryIdeaListViewModel
	{
        public Guid CategoryId { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<CategoryIdeaDto>? Ideas { get; set; }
    }
}

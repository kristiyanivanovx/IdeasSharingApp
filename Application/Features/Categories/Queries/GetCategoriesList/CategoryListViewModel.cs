using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries.GetCategoriesList
{
	public class CategoryListViewModel
	{
        public Guid CategoryId { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}

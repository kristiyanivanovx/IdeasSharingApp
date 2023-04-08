using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Ideas.Queries.GetIdeaDetail
{
    public class CategoryDto
    {
        public Guid CategoryId { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}

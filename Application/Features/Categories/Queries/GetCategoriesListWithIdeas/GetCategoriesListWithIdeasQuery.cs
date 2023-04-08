using Application.Features.Categories.Queries.GetCategoriesList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Queries.GetCategoriesListWithIdeas
{
	public class GetCategoriesListWithIdeasQuery : IRequest<List<CategoryIdeaListViewModel>>
	{
    }
}

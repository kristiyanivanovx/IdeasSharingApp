using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Commands.DeleteCategory;
using Application.Features.Categories.Commands.UpdateCategory;
using Application.Features.Categories.Queries.GetCategoriesList;
using Application.Features.Categories.Queries.GetCategoriesListWithIdeas;
using Application.Features.Ideas.Commands.DeleteIdea;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
			_mediator = mediator;
        }

		[HttpGet("all", Name = "GetAllCategories")]
		[ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCategories()
		{
			var dtos = await _mediator.Send(new GetCategoriesListQuery());
			return Ok(dtos);
		}

		[HttpGet("allwithideas", Name = "GetCategoriesWithIdeas")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> GetCategoriesWithIdeas()
		{
			var dtos = await _mediator.Send(new GetCategoriesListWithIdeasQuery());
			return Ok(dtos);
		}

		[HttpPost("create", Name = "CreateCategory")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand createCategoryCommand)
		{
			var response = await _mediator.Send(createCategoryCommand);
			return Ok(response);
		}

		[HttpPut(Name = "UpdateCategory")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> Update([FromBody] UpdateCategoryCommand updateCategoryCommand)
		{
			await _mediator.Send(updateCategoryCommand);
			return NoContent();
		}

		[HttpDelete("{categoryId}", Name = "DeleteCategory")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> Delete(Guid categoryId)
		{
			var deleteCategoryCommand = new DeleteCategoryCommand() { CategoryId = categoryId };
			await _mediator.Send(deleteCategoryCommand);
			return NoContent();
		}
	}
}

using Application.Features.Ideas;
using Application.Features.Ideas.Commands.CreateIdea;
using Application.Features.Ideas.Commands.DeleteIdea;
using Application.Features.Ideas.Commands.UpdateIdea;
using Application.Features.Ideas.Queries.GetIdeaDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class IdeaController : ControllerBase
	{
		private readonly IMediator _mediator;

        public IdeaController(IMediator mediator)
        {
			_mediator = mediator;
		}

		[HttpGet("all", Name = "GetAllIdeas")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> GetAllIdeas()
		{
			var ideaList = await _mediator.Send(new GetIdeasListQuery());
			return Ok(ideaList);
		}

		[HttpGet("{id}", Name = "GetIdeaById")]
		public async Task<IActionResult> GetIdeaById(Guid id)
		{
			return Ok(await _mediator.Send(new GetIdeaDetailQuery() { Id = id }));
		}

		[HttpPost(Name = "CreateIdea")]
		public async Task<ActionResult<Guid>> Create([FromBody] CreateIdeaCommand createIdeaCommand)
		{
			var id = await _mediator.Send(createIdeaCommand);
			return Ok(id);
		}

		[HttpPut(Name = "UpdateIdea")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> Update([FromBody] UpdateIdeaCommand updateIdeaCommand)
		{
			await _mediator.Send(updateIdeaCommand);
			return NoContent();
		}

		[HttpDelete("{ideaId}", Name = "DeleteIdea")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> Delete(Guid ideaId)
		{
			var deleteIdeaCommand = new DeleteIdeaCommand() { IdeaId = ideaId };
			await _mediator.Send(deleteIdeaCommand);
			return NoContent();
		}
	}
}

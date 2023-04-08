using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LikeController : ControllerBase
	{
		private readonly IMediator _mediator;

        public LikeController(IMediator mediator)
        {
			_mediator = mediator;
        }

		// ...
    }
}

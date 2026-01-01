using BusinessLogicLayer.Handler.ReviewHandler.DTOs;
using BusinessLogicLayer.Handler.ReviewHandler.Queries;
using BusinessLogicLayer.Handler.ReviewHandler.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Review
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllReviewsHandleRequest());

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        // GET: api/Review/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(
                new GetReviewByIdHandleRequest { ReviewId = id }
            );

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        // POST: api/Review
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateReviewHandleRequest request
        )
        {
            var result = await _mediator.Send(request);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        // DELETE: api/Review/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(
                new DeleteReviewHandleRequest { ReviewId = id }
            );

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

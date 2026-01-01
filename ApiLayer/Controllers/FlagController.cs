using BusinessLogicLayer.Handler.FlagHandler.DTOs;
using BusinessLogicLayer.Handler.FlagHandler.Queries;
using BusinessLogicLayer.Handler.FlagHandler.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlagController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FlagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Flag
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllFlagsHandleRequest());

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        // GET: api/Flag/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(
                new GetFlagByIdHandleRequest { FlagId = id }
            );

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        // POST: api/Flag
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateFlagHandleRequest request
        )
        {
            var result = await _mediator.Send(request);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        // PUT: api/Flag
        [HttpPut]
        public async Task<IActionResult> Update(
            [FromBody] UpdateFlagHandleRequest request
        )
        {
            var result = await _mediator.Send(request);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        // DELETE: api/Flag/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(
                new DeleteFlagHandleRequest { FlagId = id }
            );

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

using BusinessLogicLayer.Handler.UserHandler.DTOs;
using BusinessLogicLayer.Handler.UserHandler.Queries;
using BusinessLogicLayer.Handler.UserHandler.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using GetAllUsersHandleRequest = BusinessLogicLayer.Handler.UserHandler.DTOs.GetAllUsersHandleRequest;

namespace ApiLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/User
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllUsersHandleRequest());

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        // GET: api/User/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(
                new GetUserByIdHandleRequest { Id = id }
            );

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        // POST: api/User/register
        [HttpPost("register")]
        public async Task<IActionResult> Register(
            [FromBody] CreateUserHandleRequest request
        )
        {
            var result = await _mediator.Send(request);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        // PUT: api/User
        [HttpPut]
        public async Task<IActionResult> Update(
            [FromBody] UpdateUserHandleRequest request
        )
        {
            var result = await _mediator.Send(request);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        // DELETE: api/User/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(
                new DeleteUserHandleRequest { Id = id }
            );

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

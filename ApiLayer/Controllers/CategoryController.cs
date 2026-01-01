using BusinessLogicLayer.Handler.CategoryHandler.DTOs;
using BusinessLogicLayer.Handler.CategoryHandler.Queries;
using BusinessLogicLayer.Handler.CategoryHandler.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllCategoryHandleRequest());

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        // GET: api/Category/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(
                new GetCategoryByIdHandleRequest { Id = id }
            );

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        // POST: api/Category
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateCategoryHandleRequest request
        )
        {
            var result = await _mediator.Send(request);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        // PUT: api/Category
        [HttpPut]
        public async Task<IActionResult> Update(
            [FromBody] UpdateCategoryHandleRequest request
        )
        {
            var result = await _mediator.Send(request);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        // DELETE: api/Category/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(
                new DeleteCategoryHandleRequest { Id = id }
            );

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

using BusinessLogicLayer.Handler.ProductHandler.DTOs;
using BusinessLogicLayer.Handler.ProductHandler.Queries;
using BusinessLogicLayer.Handler.ProductHandler.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllProductsHandleRequest());

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        // GET: api/Product/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(
                new GetProductByIdHandleRequest { Id = id }
            );

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateProductHandleRequest request
        )
        {
            var result = await _mediator.Send(request);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        // PUT: api/Product
        [HttpPut]
        public async Task<IActionResult> Update(
            [FromBody] UpdateProductHandleRequest request
        )
        {
            var result = await _mediator.Send(request);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        // DELETE: api/Product/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(
                new DeleteProductHandleRequest { Id = id }
            );

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

using BusinessLogicLayer.Handler.ProductHandler.DTOs;
using BusinessLogicLayer.Handler.ProductHandler.Queries;
using BusinessLogicLayer.Handler.ProductHandler.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
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
            try
            {
                // MediatR üzerinden Handler'a istek gönderiyoruz
                var result = await _mediator.Send(new GetAllProductsHandleRequest());

                // KRİTİK DÜZELTME: Veritabanı boşsa veya MediatR hata verirse 
                // 404 dönmek yerine 200 OK ile boş bir Products listesi dönüyoruz.
                // Bu sayede Presentation katmanı (MVC) çökmez, sadece tabloyu boş gösterir.
                if (result == null || result.Products == null)
                {
                    return Ok(new { Products = new List<ProductListItemDto>(), IsSuccess = true });
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                // Bir hata olsa bile JSON formatında dönüyoruz ki ön yüz hata vermesin
                return Ok(new { Products = new List<ProductListItemDto>(), IsSuccess = false, Error = ex.Message });
            }
        }

        // GET: api/Product/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetProductByIdHandleRequest { Id = id });

                if (result == null)
                    return Ok(new { IsSuccess = false, Message = "Ürün bulunamadı" });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new { IsSuccess = false, Error = ex.Message });
            }
        }

        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductHandleRequest request)
        {
            if (request == null) return BadRequest(new { IsSuccess = false, Message = "İstek boş olamaz" });

            try
            {
                var result = await _mediator.Send(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new { IsSuccess = false, Error = ex.Message });
            }
        }

        // PUT: api/Product
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductHandleRequest request)
        {
            if (request == null) return BadRequest(new { IsSuccess = false });
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        // DELETE: api/Product/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteProductHandleRequest { Id = id });
            return Ok(result);
        }
    }
}
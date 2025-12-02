using MediatR;

namespace BusinessLogicLayer.Handler.ProductHandler.DTOs
{
    public class GetProductByIdHandleRequest : IRequest<GetProductByIdHandleResponse>
    {
        public int Id { get; set; }
    }
}
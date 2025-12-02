using MediatR;

namespace BusinessLogicLayer.Handler.ProductHandler.DTOs
{
    public class DeleteProductHandleRequest : IRequest<DeleteProductHandleResponse>
    {
        public int Id { get; set; }
    }
}
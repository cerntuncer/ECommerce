using MediatR;

namespace BusinessLogicLayer.Handler.ReviewHandler.DTOs
{
    public class CreateReviewHandleRequest : IRequest<CreateReviewHandleResponse>
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Content { get; set; } = null!;
    }
}
using MediatR;

namespace BusinessLogicLayer.Handler.ReviewHandler.DTOs
{
    public class DeleteReviewHandleRequest : IRequest<DeleteReviewHandleResponse>
    {
        public int ReviewId { get; set; }
    }
}
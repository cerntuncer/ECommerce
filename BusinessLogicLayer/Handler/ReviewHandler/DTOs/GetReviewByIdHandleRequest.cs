using MediatR;

namespace BusinessLogicLayer.Handler.ReviewHandler.DTOs
{
    public class GetReviewByIdHandleRequest : IRequest<GetReviewByIdHandleResponse>
    {
        public int ReviewId { get; set; }
    }
}
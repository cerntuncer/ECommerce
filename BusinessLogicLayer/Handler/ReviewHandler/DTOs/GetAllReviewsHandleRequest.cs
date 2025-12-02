using MediatR;

namespace BusinessLogicLayer.Handler.ReviewHandler.DTOs
{
    public class GetAllReviewsHandleRequest : IRequest<GetAllReviewsHandleResponse>
    {
        // Tüm yorumları listelemek için boş request
    }
}
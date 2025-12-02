using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using BusinessLogicLayer.Handler.ReviewHandler.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Handler.ReviewHandler.Queries
{
    public class GetReviewByIdHandle : IRequestHandler<GetReviewByIdHandleRequest, GetReviewByIdHandleResponse>
    {
        private readonly IReviewRepository _reviewRepository;

        public GetReviewByIdHandle(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public Task<GetReviewByIdHandleResponse> Handle(GetReviewByIdHandleRequest request, CancellationToken cancellationToken)
        {
            var review = _reviewRepository.Find(request.ReviewId);

            if (review == null)
            {
                return Task.FromResult(new GetReviewByIdHandleResponse
                {
                    Found = false,
                    Message = $"Review bulunamadı. ID: {request.ReviewId}"
                });
            }

            return Task.FromResult(new GetReviewByIdHandleResponse
            {
                ReviewId = review.Id,
                ProductId = review.ProductId,
                UserId = review.UserId,
                Rating = review.Rating,
                Content = review.Content,
                ReviewDate = review.CreatedDate,
                Found = true,
                Message = $"Review başarıyla getirildi. ID: {review.Id}"
            });
        }
    }
}
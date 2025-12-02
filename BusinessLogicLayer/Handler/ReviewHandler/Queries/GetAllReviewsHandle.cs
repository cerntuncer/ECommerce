using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using BusinessLogicLayer.Handler.ReviewHandler.DTOs;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Handler.ReviewHandler.Queries
{
    public class GetAllReviewsHandle : IRequestHandler<GetAllReviewsHandleRequest, GetAllReviewsHandleResponse>
    {
        private readonly IReviewRepository _reviewRepository;

        public GetAllReviewsHandle(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public Task<GetAllReviewsHandleResponse> Handle(GetAllReviewsHandleRequest request, CancellationToken cancellationToken)
        {
            var reviews = _reviewRepository.GetAll();

            if (!reviews.Any())
            {
                return Task.FromResult(new GetAllReviewsHandleResponse
                {
                    IsSuccess = false,
                    Message = "Kayıtlı aktif yorum bulunamadı."
                });
            }

            var responseList = reviews.Select(r => new ReviewListItemDto
            {
                ReviewId = r.Id,
                ProductId = r.ProductId,
                UserId = r.UserId,
                Rating = r.Rating,
                Content = r.Content,
                ReviewDate = r.CreatedDate
            }).ToList();

            return Task.FromResult(new GetAllReviewsHandleResponse
            {
                IsSuccess = true,
                Reviews = responseList,
                Message = $"{responseList.Count} adet yorum listelendi."
            });
        }
    }
}
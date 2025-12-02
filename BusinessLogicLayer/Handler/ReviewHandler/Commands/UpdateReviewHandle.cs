using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using BusinessLogicLayer.Handler.ReviewHandler.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Handler.ReviewHandler.Commands
{
    public class UpdateReviewHandle : IRequestHandler<UpdateReviewHandleRequest, UpdateReviewHandleResponse>
    {
        private readonly IReviewRepository _reviewRepository;

        public UpdateReviewHandle(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public Task<UpdateReviewHandleResponse> Handle(UpdateReviewHandleRequest request, CancellationToken cancellationToken)
        {
            // Review'u ID ile bul
            var reviewToUpdate = _reviewRepository.Find(request.ReviewId);

            if (reviewToUpdate == null)
            {
                return Task.FromResult(new UpdateReviewHandleResponse
                {
                    IsSuccess = false,
                    Message = $"Güncellenecek yorum bulunamadı. ID: {request.ReviewId}"
                });
            }

            // Alanları güncelle
            reviewToUpdate.Rating = request.Rating;
            reviewToUpdate.Content = request.Content;

            // Güncelleme işlemi
            _reviewRepository.Update(reviewToUpdate);

            return Task.FromResult(new UpdateReviewHandleResponse
            {
                ReviewId = reviewToUpdate.Id,
                IsSuccess = true,
                Message = $"Yorum başarıyla güncellendi. ID: {reviewToUpdate.Id}"
            });
        }
    }
}
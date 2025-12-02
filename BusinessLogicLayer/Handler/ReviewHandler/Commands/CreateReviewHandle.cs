using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using BusinessLogicLayer.Handler.ReviewHandler.DTOs;
using ECommerce.DatabaseAccessLayer.Entities;
using ECommerce.DatabaseAccessLayer.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Handler.ReviewHandler.Commands
{
    public class CreateReviewHandle : IRequestHandler<CreateReviewHandleRequest, CreateReviewHandleResponse>
    {
        private readonly IReviewRepository _reviewRepository;

        public CreateReviewHandle(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public Task<CreateReviewHandleResponse> Handle(CreateReviewHandleRequest request, CancellationToken cancellationToken)
        {
            var newReview = new Review
            {
                ProductId = request.ProductId,
                UserId = request.UserId,
                Rating = request.Rating,
                Content = request.Content,
                ReviewDate = DateTime.Now
            };

            _reviewRepository.Add(newReview);

            return Task.FromResult(new CreateReviewHandleResponse
            {
                ReviewId = newReview.Id,
                Success = true,
                Message = $"Yorum başarıyla oluşturuldu. ID: {newReview.Id}"
            });
        }
    }
}
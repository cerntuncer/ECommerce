using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using BusinessLogicLayer.Handler.ReviewHandler.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Handler.ReviewHandler.Commands
{
    public class DeleteReviewHandle : IRequestHandler<DeleteReviewHandleRequest, DeleteReviewHandleResponse>
    {
        private readonly IReviewRepository _reviewRepository;

        public DeleteReviewHandle(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public Task<DeleteReviewHandleResponse> Handle(DeleteReviewHandleRequest request, CancellationToken cancellationToken)
        {
            var reviewToDelete = _reviewRepository.Find(request.ReviewId);

            if (reviewToDelete == null)
            {
                return Task.FromResult(new DeleteReviewHandleResponse
                {
                    IsSuccess = false,
                    Message = $"Silinecek yorum bulunamadı. ID: {request.ReviewId}"
                });
            }

            _reviewRepository.Delete(reviewToDelete); // Soft Delete işlemi

            return Task.FromResult(new DeleteReviewHandleResponse
            {
                IsSuccess = true,
                Message = $"Yorum başarıyla silindi (Soft Delete). ID: {request.ReviewId}"
            });
        }
    }
}
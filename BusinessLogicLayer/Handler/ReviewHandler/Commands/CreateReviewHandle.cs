using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using BusinessLogicLayer.Handler.ReviewHandler.DTOs;
using BusinessLogicLayer.Services.Analysis;
using ECommerce.DatabaseAccessLayer.Entities;
using ECommerce.DatabaseAccessLayer.Models.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Handler.ReviewHandler.Commands
{
    public class CreateReviewHandle : IRequestHandler<CreateReviewHandleRequest, CreateReviewHandleResponse>
    {
        // Constructor'a IAnalysisService ekle
        private readonly IReviewRepository _reviewRepository;
        private readonly IAnalysisService _analysisService; // EKLE
        private readonly IProductRepository _productRepository; // Ürün bayrağını güncellemek için

        public CreateReviewHandle(IReviewRepository reviewRepository, IAnalysisService analysisService, IProductRepository productRepository)
        {
            _reviewRepository = reviewRepository;
            _analysisService = analysisService;
            _productRepository = productRepository;
        }

        public async Task<CreateReviewHandleResponse> Handle(CreateReviewHandleRequest request, CancellationToken cancellationToken)
        {
            // 1. AI Analizini Yap
            var score = await _analysisService.GetSentimentScoreAsync(request.Content);
            var isConsistent = _analysisService.CheckConsistency(request.Rating, score);

            // 2. Yorumu Analiz Sonuçlarıyla Kaydet
            var newReview = new Review
            {
                ProductId = request.ProductId,
                UserId = request.UserId,
                Rating = request.Rating,
                Content = request.Content,
                NLPSentimentScore = score,
                IsRatingConsistent = isConsistent,
                ReviewDate = DateTime.Now
            };

            _reviewRepository.Add(newReview);

            // 3. Ürünün Bayrağını Güncelle (Opsiyonel: Eğer son yorum tutarsızsa ürünü işaretle)
            var product = _productRepository.Find(request.ProductId);
            product.FlagId = isConsistent ? 1 : 2; // 1: Yeşil, 2: Kırmızı
            _productRepository.Update(product);

            return new CreateReviewHandleResponse { IsSuccess = true, Message = "Analiz Edildi ve Kaydedildi." };
        }
    }
}
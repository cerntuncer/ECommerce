using MediatR;

namespace BusinessLogicLayer.Handler.ReviewHandler.DTOs
{
    // Komut, cevabının UpdateReviewHandleResponse olacağını belirtir
    public class UpdateReviewHandleRequest : IRequest<UpdateReviewHandleResponse>
    {
        public int ReviewId { get; set; }

        // Güncellenebilecek alanlar
        public int Rating { get; set; }
        public string Content { get; set; } = null!;
    }
}
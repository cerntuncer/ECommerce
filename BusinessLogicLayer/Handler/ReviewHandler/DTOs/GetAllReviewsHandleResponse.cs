using System.Collections.Generic;

namespace BusinessLogicLayer.Handler.ReviewHandler.DTOs
{
    // Listede yer alacak her bir yorumun temel bilgilerini tutan iç DTO
    public class ReviewListItemDto
    {
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Content { get; set; } = null!;
        public DateTime ReviewDate { get; set; }
    }

    // Asıl liste yanıtını taşıyan DTO
    public class GetAllReviewsHandleResponse
    {
        public List<ReviewListItemDto> Reviews { get; set; } = new List<ReviewListItemDto>();
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
    }
}
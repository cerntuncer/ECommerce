using System.Collections.Generic;

namespace BusinessLogicLayer.Handler.ProductHandler.DTOs
{
    // Listede yer alacak her bir Ürünün temel bilgilerini tutan iç DTO
    public class ProductListItemDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public decimal AverageRating { get; set; }
        public int CategoryId { get; set; }
        public int FlagId { get; set; }
    }

    // Asıl liste yanıtını taşıyan DTO
    public class GetAllProductsHandleResponse
    {
        public List<ProductListItemDto> Products { get; set; } = new List<ProductListItemDto>();
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
    }
}
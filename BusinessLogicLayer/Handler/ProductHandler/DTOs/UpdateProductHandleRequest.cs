using MediatR;

namespace BusinessLogicLayer.Handler.ProductHandler.DTOs
{
    public class UpdateProductHandleRequest : IRequest<UpdateProductHandleResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? ImageURL { get; set; }
        public int CategoryId { get; set; }
    }
}
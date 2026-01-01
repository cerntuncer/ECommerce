namespace BusinessLogicLayer.Handler.ProductHandler.DTOs
{
    public class GetProductByIdHandleResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? FlagName { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
    }
}
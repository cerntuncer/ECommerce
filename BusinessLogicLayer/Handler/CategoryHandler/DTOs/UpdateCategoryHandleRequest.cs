using MediatR;

namespace BusinessLogicLayer.Handler.CategoryHandler.DTOs
{
    // Güncelleme isteği, Id ve yeni adı içerir
    public class UpdateCategoryHandleRequest : IRequest<UpdateCategoryHandleResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
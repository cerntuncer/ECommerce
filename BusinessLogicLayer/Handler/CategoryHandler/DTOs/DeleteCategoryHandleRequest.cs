using MediatR;

namespace BusinessLogicLayer.Handler.CategoryHandler.DTOs
{
    // Silme isteği sadece Id içerir
    public class DeleteCategoryHandleRequest : IRequest<DeleteCategoryHandleResponse>
    {
        public int Id { get; set; }
    }
}
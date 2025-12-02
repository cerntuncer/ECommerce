using MediatR;

namespace BusinessLogicLayer.Handler.CategoryHandler.DTOs
{
    public class CreateCategoryHandleRequest : IRequest<CreateCategoryHandleResponse>
    {
        public string Name { get; set; } = null!;
    }
}
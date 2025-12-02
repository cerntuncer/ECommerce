using MediatR;

namespace BusinessLogicLayer.Handler.CategoryHandler.DTOs
{
    public class GetCategoryByIdHandleRequest : IRequest<GetCategoryByIdHandleResponse>
    {
        public int Id { get; set; }
    }
}
using MediatR;

namespace BusinessLogicLayer.Handler.CategoryHandler.DTOs
{
    public class GetAllCategoryHandleRequest : IRequest<GetAllCategoryHandleResponse>
    {
        // Tüm kategorileri listelemek için boş bir request
    }
}
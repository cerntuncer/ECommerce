using MediatR;

namespace BusinessLogicLayer.Handler.ProductHandler.DTOs
{
    // Handler'ı tetiklemek için kullanılan boş Request DTO'su
    public class GetAllProductsHandleRequest : IRequest<GetAllProductsHandleResponse>
    {
        // Tüm ürünleri listelemek için özel bir parametre gerekmez
    }
}
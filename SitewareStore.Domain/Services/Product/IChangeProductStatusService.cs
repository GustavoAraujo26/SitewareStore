using SitewareStore.Domain.DTOs.Product;
using SitewareStore.Domain.Requests;

namespace SitewareStore.Domain.Services.Product
{
    /// <summary>
    /// Interface do serviço de alteração de status de produto
    /// </summary>
    public interface IChangeProductStatusService : IComplexServiceBase<ChangeProductStatusRequest, ProductDTO>
    {
    }
}

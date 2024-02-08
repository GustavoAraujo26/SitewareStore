using SitewareStore.Domain.DTOs.Product;

namespace SitewareStore.Domain.Services.Product
{
    /// <summary>
    /// Interface do serviço de listagem de produtos
    /// </summary>
    public interface IListProductService : IListServiceBase<ProductListDTO>
    {
    }
}

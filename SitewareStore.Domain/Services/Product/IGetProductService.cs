using SitewareStore.Domain.DTOs.Product;

namespace SitewareStore.Domain.Services.Product
{
    /// <summary>
    /// Interface do serviço de busca de um produto específico
    /// </summary>
    public interface IGetProductService : ISimpleServiceBase<ProductDTO>
    {
    }
}

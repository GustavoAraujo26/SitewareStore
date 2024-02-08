using SitewareStore.Domain.DTOs.Product;
using SitewareStore.Domain.Requests;

namespace SitewareStore.Domain.Services.Product
{
    /// <summary>
    /// Interface do serviço de persistência do produto
    /// </summary>
    public interface ISaveProductService : IComplexServiceBase<SaveProductRequest, ProductDTO>
    {
    }
}

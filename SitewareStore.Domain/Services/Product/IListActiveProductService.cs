using SitewareStore.Domain.DTOs.Product;

namespace SitewareStore.Domain.Services.Product
{
    /// <summary>
    /// Interface do serviço de listagem de produtos ativos
    /// </summary>
    public interface IListActiveProductService : IListServiceBase<Domain.Entities.Product>
    {
    }
}

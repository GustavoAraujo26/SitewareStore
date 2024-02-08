using AutoMapper;
using SitewareStore.Domain.DTOs.Product;
using SitewareStore.Domain.Repositories;
using SitewareStore.Domain.Services.Product;
using SitewareStore.Infra.CrossCutting.Responses;
using System.Net;

namespace SitewareStore.Service.Contracts.Product
{
    public class DeleteProductService : IDeleteProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IRepositoryBase repositoryBase;

        private readonly IMapper mapper;

        public DeleteProductService(IProductRepository productRepository, IRepositoryBase repositoryBase, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.repositoryBase = repositoryBase;
            this.mapper = mapper;
        }

        public async Task<InternalResponse<ProductDTO>> Execute(Guid id)
        {
            try
            {
                if (id.Equals(Guid.Empty))
                    return InternalResponse<ProductDTO>.Custom(HttpStatusCode.BadRequest, "ID do produto inválido.");

                using (var db = repositoryBase.CreateDbConnection())
                using (var transaction = repositoryBase.CreateTransaction())
                {
                    var currentProduct = await productRepository.Get(db, id);
                    if (currentProduct is null)
                        return InternalResponse<ProductDTO>.Custom(HttpStatusCode.NotFound, "Produto não encontrado.");

                    await productRepository.Delete(db, id);

                    var dto = mapper.Map<ProductDTO>(currentProduct);

                    return InternalResponse<ProductDTO>.Success(dto);
                }
            }
            catch(Exception ex)
            {
                return InternalResponse<ProductDTO>.Error(ex);
            }
        }
    }
}

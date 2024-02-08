using AutoMapper;
using SitewareStore.Domain.DTOs.Product;
using SitewareStore.Domain.Enums;
using SitewareStore.Domain.Repositories;
using SitewareStore.Domain.Requests;
using SitewareStore.Domain.Services.Product;
using SitewareStore.Infra.CrossCutting.Responses;
using System.Net;

namespace SitewareStore.Service.Contracts.Product
{
    public class ChangeProductStatusService : IChangeProductStatusService
    {
        private readonly IProductRepository productRepository;
        private readonly IRepositoryBase repositoryBase;

        private readonly IMapper mapper;

        public ChangeProductStatusService(IProductRepository productRepository, IRepositoryBase repositoryBase, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.repositoryBase = repositoryBase;
            this.mapper = mapper;
        }

        public async Task<InternalResponse<ProductDTO>> Execute(ChangeProductStatusRequest request)
        {
            try
            {
                var validationResponse = request.Validate();
                if (!validationResponse.IsSuccess())
                    return InternalResponse<ProductDTO>.Copy(validationResponse);

                using (var db = repositoryBase.CreateDbConnection())
                using (var transaction = repositoryBase.CreateTransaction())
                {
                    var product = await productRepository.Get(db, request.Id);
                    if (product is null)
                        return InternalResponse<ProductDTO>.Custom(HttpStatusCode.NotFound, "Não foi possível encontrar o produto.");

                    if (request.Status == StatusType.Active)
                        product.Activate();
                    else
                        product.Cancel();

                    await productRepository.Save(db, product);

                    var dto = mapper.Map<ProductDTO>(product);

                    repositoryBase.CompleteTransaction(transaction);

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

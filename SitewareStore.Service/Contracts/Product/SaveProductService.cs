using AutoMapper;
using Microsoft.Data.SqlClient;
using SitewareStore.Domain.DTOs.Product;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Repositories;
using SitewareStore.Domain.Requests;
using SitewareStore.Domain.Services.Product;
using SitewareStore.Infra.CrossCutting.Responses;
using System.Net;

namespace SitewareStore.Service.Contracts.Product
{
    public class SaveProductService : ISaveProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IPromotionRepository promotionRepository;
        private readonly IRepositoryBase repositoryBase;

        private readonly IMapper mapper;

        public SaveProductService(IProductRepository productRepository, 
            IPromotionRepository promotionRepository, IRepositoryBase repositoryBase, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.promotionRepository = promotionRepository;
            this.repositoryBase = repositoryBase;
            this.mapper = mapper;
        }

        public async Task<InternalResponse<ProductDTO>> Execute(SaveProductRequest request)
        {
            try
            {
                var validationResponse = request.Validate();
                if (!validationResponse.IsSuccess())
                    return InternalResponse<ProductDTO>.Copy(validationResponse);

                using (var db = repositoryBase.CreateDbConnection())
                using (var transaction = repositoryBase.CreateTransaction())
                {
                    var product = await BuildEntity(db, request);
                    if (product is null)
                        return InternalResponse<ProductDTO>.Custom(HttpStatusCode.NotFound, "Produto não encontrado.");

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

        private async Task<Domain.Entities.Product> BuildEntity(SqlConnection db, SaveProductRequest request)
        {
            if (request.Id is not null && !request.Id.Equals(Guid.Empty))
            {
                Domain.Entities.Promotion promotionEntity = null;
                if (request.PromotionId.HasValue && !request.PromotionId.Value.Equals(Guid.Empty))
                    promotionEntity = await promotionRepository.Get(db, request.PromotionId.Value);
                
                var productEntity = await productRepository.Get(db, request.Id.Value);
                productEntity.UpdateBasicData(request.Name, request.Price, promotionEntity);

                return productEntity;
            }
            else
                return mapper.Map<Domain.Entities.Product>(request);
        }
    }
}

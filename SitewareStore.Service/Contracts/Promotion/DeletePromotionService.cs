using AutoMapper;
using Microsoft.Data.SqlClient;
using SitewareStore.Domain.DTOs.Promotion;
using SitewareStore.Domain.Repositories;
using SitewareStore.Domain.Services.Promotion;
using SitewareStore.Infra.CrossCutting.Responses;
using System.Net;

namespace SitewareStore.Service.Contracts.Promotion
{
    public class DeletePromotionService : IDeletePromotionService
    {
        private readonly IPromotionRepository promotionRepository;
        private readonly IProductRepository productRepository;
        private readonly IRepositoryBase repositoryBase;

        private readonly IMapper mapper;

        public DeletePromotionService(IPromotionRepository promotionRepository, 
            IProductRepository productRepository, IRepositoryBase repositoryBase, IMapper mapper)
        {
            this.promotionRepository = promotionRepository;
            this.productRepository = productRepository;
            this.repositoryBase = repositoryBase;
            this.mapper = mapper;
        }

        public async Task<InternalResponse<PromotionDTO>> Execute(Guid id)
        {
            try
            {
                if (id.Equals(Guid.Empty))
                    return InternalResponse<PromotionDTO>.Custom(HttpStatusCode.BadRequest, "ID da promoção inválido.");

                using (var db = repositoryBase.CreateDbConnection())
                using (var transaction = repositoryBase.CreateTransaction())
                {
                    var currentPromotion = await promotionRepository.Get(db, id);
                    if (currentPromotion is null)
                        return InternalResponse<PromotionDTO>.Custom(HttpStatusCode.NotFound, "Produto não encontrado.");

                    var linkValidation = await CheckProductLink(db, id);
                    if (!linkValidation.IsSuccess())
                        return linkValidation;

                    await promotionRepository.Delete(db, id);

                    var dto = mapper.Map<PromotionDTO>(currentPromotion);

                    return InternalResponse<PromotionDTO>.Success(dto);
                }
            }
            catch(Exception ex)
            {
                return InternalResponse<PromotionDTO>.Error(ex);
            }
        }

        private async Task<InternalResponse<PromotionDTO>> CheckProductLink(SqlConnection db, Guid id)
        {
            var nameList = await productRepository.ListNamesByPromotionId(db, id);
            if (nameList is null || !nameList.Any())
                return InternalResponse<PromotionDTO>.Custom(HttpStatusCode.OK, "Ok");

            var productNames = string.Join(", ", nameList);

            var message = $"Não é possível apagar uma promoção vinculada à um ou mais produtos. " +
                $"Remova o vínculo primeiro. Produtos vinculados: {productNames}";

            return InternalResponse<PromotionDTO>.Custom(HttpStatusCode.BadRequest, message);
        }
    }
}

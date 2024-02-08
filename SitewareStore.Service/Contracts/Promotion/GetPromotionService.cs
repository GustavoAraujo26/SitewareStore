using AutoMapper;
using SitewareStore.Domain.DTOs.Promotion;
using SitewareStore.Domain.Repositories;
using SitewareStore.Domain.Services.Promotion;
using SitewareStore.Infra.CrossCutting.Responses;
using System.Net;

namespace SitewareStore.Service.Contracts.Promotion
{
    internal class GetPromotionService : IGetPromotionService
    {
        private readonly IPromotionRepository promotionRepository;
        private readonly IRepositoryBase repositoryBase;

        private readonly IMapper mapper;

        public GetPromotionService(IPromotionRepository promotionRepository, IRepositoryBase repositoryBase, IMapper mapper)
        {
            this.promotionRepository = promotionRepository;
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
                {
                    var currentPromotion = await promotionRepository.Get(db, id);
                    if (currentPromotion is null)
                        return InternalResponse<PromotionDTO>.Custom(HttpStatusCode.NotFound, "Produto não encontrado.");

                    var dto = mapper.Map<PromotionDTO>(currentPromotion);

                    return InternalResponse<PromotionDTO>.Success(dto);
                }
            }
            catch(Exception ex)
            {
                return InternalResponse<PromotionDTO>.Error(ex);
            }
        }
    }
}

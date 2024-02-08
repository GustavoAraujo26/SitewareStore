using AutoMapper;
using SitewareStore.Domain.DTOs.Promotion;
using SitewareStore.Domain.Enums;
using SitewareStore.Domain.Repositories;
using SitewareStore.Domain.Requests;
using SitewareStore.Domain.Services.Promotion;
using SitewareStore.Infra.CrossCutting.Responses;
using System.Net;

namespace SitewareStore.Service.Contracts.Promotion
{
    public class ChangePromotionStatusService : IChangePromotionStatusService
    {
        private readonly IPromotionRepository promotionRepository;
        private readonly IRepositoryBase repositoryBase;

        private readonly IMapper mapper;

        public ChangePromotionStatusService(IPromotionRepository promotionRepository, IRepositoryBase repositoryBase, IMapper mapper)
        {
            this.promotionRepository = promotionRepository;
            this.repositoryBase = repositoryBase;
            this.mapper = mapper;
        }

        public async Task<InternalResponse<PromotionDTO>> Execute(ChangePromotionStatusRequest request)
        {
            try
            {
                var validationResponse = request.Validate();
                if (!validationResponse.IsSuccess())
                    return InternalResponse<PromotionDTO>.Copy(validationResponse);

                using (var db = repositoryBase.CreateDbConnection())
                using (var transaction = repositoryBase.CreateTransaction())
                {
                    var promotion = await promotionRepository.Get(db, request.Id);
                    if (promotion is null)
                        return InternalResponse<PromotionDTO>.Custom(HttpStatusCode.NotFound, "Não foi possível encontrar a promoção.");

                    if (request.Status == StatusType.Active)
                        promotion.Activate();
                    else
                        promotion.Cancel();

                    await promotionRepository.Save(db, promotion);

                    var dto = mapper.Map<PromotionDTO>(promotion);

                    repositoryBase.CompleteTransaction(transaction);

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

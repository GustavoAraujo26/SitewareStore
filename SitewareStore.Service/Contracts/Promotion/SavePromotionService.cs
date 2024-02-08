using AutoMapper;
using Microsoft.Data.SqlClient;
using SitewareStore.Domain.DTOs.Promotion;
using SitewareStore.Domain.Repositories;
using SitewareStore.Domain.Requests;
using SitewareStore.Domain.Services.Promotion;
using SitewareStore.Infra.CrossCutting.Responses;
using System.Net;

namespace SitewareStore.Service.Contracts.Promotion
{
    public class SavePromotionService : ISavePromotionService
    {
        private readonly IPromotionRepository promotionRepository;
        private readonly IRepositoryBase repositoryBase;

        private readonly IMapper mapper;

        public SavePromotionService(IPromotionRepository promotionRepository, 
            IRepositoryBase repositoryBase, IMapper mapper)
        {
            this.promotionRepository = promotionRepository;
            this.repositoryBase = repositoryBase;
            this.mapper = mapper;
        }

        public async Task<InternalResponse<PromotionDTO>> Execute(SavePromotionRequest request)
        {
            try
            {
                var validationResponse = request.Validate();
                if (!validationResponse.IsSuccess())
                    return InternalResponse<PromotionDTO>.Copy(validationResponse);

                using (var db = repositoryBase.CreateDbConnection())
                using (var transaction = repositoryBase.CreateTransaction())
                {
                    var promotion = await BuildEntity(db, request);
                    if (promotion is null)
                        return InternalResponse<PromotionDTO>.Custom(HttpStatusCode.NotFound, "Promoção não encontrada.");

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

        private async Task<Domain.Entities.Promotion> BuildEntity(SqlConnection db, SavePromotionRequest request)
        {
            if (request.Id is not null && !request.Id.Equals(Guid.Empty))
            {
                var promotionEntity = await promotionRepository.Get(db, request.Id.Value);
                promotionEntity.UpdateBasicData(request.Observation, request.Type, request.CutQuantity, request.Percentage, request.Price);

                return promotionEntity;
            }
            else
                return mapper.Map<Domain.Entities.Promotion>(request);
        }
    }
}

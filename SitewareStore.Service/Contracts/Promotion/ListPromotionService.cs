using SitewareStore.Domain.DTOs.Promotion;
using SitewareStore.Domain.Repositories;
using SitewareStore.Domain.Services.Promotion;
using SitewareStore.Infra.CrossCutting.Responses;

namespace SitewareStore.Service.Contracts.Promotion
{
    public class ListPromotionService : IListPromotionService
    {
        private readonly IPromotionRepository promotionRepository;
        private readonly IRepositoryBase repositoryBase;

        public ListPromotionService(IPromotionRepository promotionRepository, IRepositoryBase repositoryBase)
        {
            this.promotionRepository = promotionRepository;
            this.repositoryBase = repositoryBase;
        }

        public async Task<InternalResponse<PromotionListDTO>> Execute()
        {
            try
            {
                using (var db = repositoryBase.CreateDbConnection())
                {
                    var productList = await promotionRepository.ListAll(db);

                    return InternalResponse<PromotionListDTO>.Success(productList);
                }
            }
            catch (Exception ex)
            {
                return InternalResponse<PromotionListDTO>.Error(ex);
            }
        }
    }
}

using SitewareStore.Domain.DTOs.Promotion;
using SitewareStore.Domain.Services.Promotion;
using SitewareStore.Infra.CrossCutting.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitewareStore.Service.Contracts.Promotion
{
    internal class DeletePromotionService : IDeletePromotionService
    {
        public Task<InternalResponse<PromotionDTO>> Execute(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

using SitewareStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitewareStore.Domain.Repositories
{
    public interface IPromotionRepository
    {
        Promotion GetPromotion(Guid id);

    }
}

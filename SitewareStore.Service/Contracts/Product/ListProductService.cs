using SitewareStore.Domain.DTOs.Product;
using SitewareStore.Domain.Services.Product;
using SitewareStore.Infra.CrossCutting.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitewareStore.Service.Contracts.Product
{
    internal class ListProductService : IListProductService
    {
        public Task<InternalResponse<ProductListDTO>> Execute()
        {
            throw new NotImplementedException();
        }
    }
}

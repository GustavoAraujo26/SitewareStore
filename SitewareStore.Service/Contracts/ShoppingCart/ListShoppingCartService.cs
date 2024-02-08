using SitewareStore.Domain.DTOs.Cart;
using SitewareStore.Domain.Services.ShoppingCart;
using SitewareStore.Infra.CrossCutting.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitewareStore.Service.Contracts.ShoppingCart
{
    internal class ListShoppingCartService : IListShoppingCartService
    {
        public Task<InternalResponse<ShoppingCartListDTO>> Execute()
        {
            throw new NotImplementedException();
        }
    }
}

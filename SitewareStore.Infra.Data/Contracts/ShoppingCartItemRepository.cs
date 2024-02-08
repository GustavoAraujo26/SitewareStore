using Microsoft.Data.SqlClient;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitewareStore.Infra.Data.Contracts
{
    public class ShoppingCartItemRepository : IShoppingCartItemRepository
    {
        public Task Delete(SqlConnection db, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCartItem> Get(SqlConnection db, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ShoppingCartItem>> ListItems(SqlConnection db, Guid cartId)
        {
            throw new NotImplementedException();
        }

        public Task Save(SqlConnection db, Guid cartId, List<ShoppingCartItem> itemList)
        {
            throw new NotImplementedException();
        }
    }
}

using Microsoft.Data.SqlClient;
using SitewareStore.Domain.DTOs.Cart;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitewareStore.Infra.Data.Contracts
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        public Task<ShoppingCart> Get(SqlConnection db, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ShoppingCartDTO>> ListAll(SqlConnection db)
        {
            throw new NotImplementedException();
        }

        public Task Save(SqlConnection db, ShoppingCart cart)
        {
            throw new NotImplementedException();
        }
    }
}

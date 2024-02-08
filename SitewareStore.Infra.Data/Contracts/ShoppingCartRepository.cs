using Microsoft.Data.SqlClient;
using SitewareStore.Domain.DTOs.Cart;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Repositories;
using Dapper;
using AutoMapper;
using SitewareStore.Domain.Models;
using SitewareStore.Infra.Data.Sql;

namespace SitewareStore.Infra.Data.Contracts
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly IShoppingCartItemRepository itemRepository;

        private readonly IMapper mapper;

        public ShoppingCartRepository(IShoppingCartItemRepository itemRepository, IMapper mapper)
        {
            this.itemRepository = itemRepository;
            this.mapper = mapper;
        }

        public async Task<ShoppingCart> Get(SqlConnection db, Guid id)
        {
            var cartModel = await db.QueryFirstOrDefaultAsync<ShoppingCartModel>(ShoppingCartSql.GetById, new { id });
            if (cartModel is null)
                return null;

            var cartItemList = await itemRepository.ListItems(db, id);

            var container = new Tuple<ShoppingCartModel, List<ShoppingCartItem>>(cartModel, cartItemList);

            return mapper.Map<ShoppingCart>(container);
        }

        public async Task<List<ShoppingCartListDTO>> ListAll(SqlConnection db) =>
            (await db.QueryAsync<ShoppingCartListDTO>(ShoppingCartSql.ListAll)).ToList();

        public async Task Save(SqlConnection db, ShoppingCart cart)
        {
            var cartModel = mapper.Map<ShoppingCartModel>(cart);
            
            var sql = ShoppingCartSql.Insert;

            var currentId = await db.QueryFirstOrDefaultAsync<Guid?>(ShoppingCartSql.CheckIfExists, new { id = cart.Id });
            if (currentId is not null && !currentId.Value.Equals(Guid.Empty))
                sql = ShoppingCartSql.Update;

            await db.ExecuteAsync(sql, cartModel);

            await itemRepository.Save(db, cart.Id, cart.Items);
        }
    }
}

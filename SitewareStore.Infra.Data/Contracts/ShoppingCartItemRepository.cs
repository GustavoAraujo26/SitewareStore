using AutoMapper;
using Microsoft.Data.SqlClient;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Repositories;
using Dapper;
using SitewareStore.Infra.Data.Sql;
using SitewareStore.Domain.Models;

namespace SitewareStore.Infra.Data.Contracts
{
    public class ShoppingCartItemRepository : IShoppingCartItemRepository
    {
        private readonly IProductRepository productRepository;

        private readonly IMapper mapper;

        public ShoppingCartItemRepository(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task Delete(SqlConnection db, Guid id) =>
            await db.ExecuteAsync(ShoppingCartItemSql.Delete, new { id });

        public async Task<ShoppingCartItem> Get(SqlConnection db, Guid id)
        {
            var cartItemModel = await db.QueryFirstOrDefaultAsync<ShoppingCartItemModel>(ShoppingCartItemSql.GetById, new { id });
            if (cartItemModel is null)
                return null;

            var productEntity = await productRepository.Get(db, cartItemModel.ProductId);

            var container = new Tuple<ShoppingCartItemModel, Product>(cartItemModel, productEntity);

            return mapper.Map<ShoppingCartItem>(container);
        }

        public async Task<List<ShoppingCartItem>> ListItems(SqlConnection db, Guid cartId)
        {
            List<ShoppingCartItem> result = new List<ShoppingCartItem>();

            var cartItemList = (await db.QueryAsync<ShoppingCartItemModel>(ShoppingCartItemSql.ListByCartId, new { cartId })).ToList();
            if (cartItemList is null || !cartItemList.Any())
                return result;

            foreach(var cartItemModel in cartItemList)
            {
                var productEntity = await productRepository.Get(db, cartItemModel.ProductId);

                var container = new Tuple<ShoppingCartItemModel, Product>(cartItemModel, productEntity);

                var cartItemEntity = mapper.Map<ShoppingCartItem>(container);

                result.Add(cartItemEntity);
            }

            return result;
        }

        public async Task Save(SqlConnection db, Guid cartId, List<ShoppingCartItem> itemList)
        {
            if (itemList is null || !itemList.Any())
                return;

            var container = new Tuple<Guid, List<ShoppingCartItem>>(cartId, itemList);
            var cartItemModelList = mapper.Map<List<ShoppingCartItemModel>>(container);

            foreach (var item in cartItemModelList)
            {
                var sql = ShoppingCartItemSql.Insert;

                var currentId = await db.QueryFirstOrDefaultAsync<Guid?>(ShoppingCartItemSql.CheckIfExists, new { id = item.Id });
                if (currentId is not null && !currentId.Value.Equals(Guid.Empty))
                    sql  = ShoppingCartItemSql.Update;

                await db.ExecuteAsync(sql, item);
            }
        }
    }
}

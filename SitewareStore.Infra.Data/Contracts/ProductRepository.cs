using AutoMapper;
using Microsoft.Data.SqlClient;
using SitewareStore.Domain.DTOs.Product;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Repositories;
using Dapper;
using SitewareStore.Infra.Data.Sql;
using SitewareStore.Domain.Models;

namespace SitewareStore.Infra.Data.Contracts
{
    public class ProductRepository : IProductRepository
    {
        private readonly IPromotionRepository promotionRepository;

        private readonly IMapper mapper;

        public ProductRepository(IPromotionRepository promotionRepository, IMapper mapper)
        {
            this.promotionRepository = promotionRepository;
            this.mapper = mapper;
        }

        public async Task Delete(SqlConnection db, Guid id) =>
            await db.ExecuteAsync(ProductSql.Delete, new { id });

        public async Task<Product> Get(SqlConnection db, Guid id)
        {
            var productModel = await db.QueryFirstOrDefaultAsync<ProductModel>(ProductSql.GetById, new { id });
            if (productModel is null)
                return null;

            Promotion promotionEntity = null;
            if (productModel.PromotionId.HasValue && !productModel.PromotionId.Value.Equals(Guid.Empty))
                promotionEntity = await promotionRepository.Get(db, productModel.PromotionId.Value);

            var container = new Tuple<ProductModel, Promotion>(productModel, promotionEntity);

            return mapper.Map<Product>(container);
        }

        public async Task<List<Product>> ListActives(SqlConnection db)
        {
            var result = new List<Product>();

            var productIdList = (await db.QueryAsync<Guid>(ProductSql.ListActives)).ToList();
            if (productIdList is null || !productIdList.Any())
                return result;

            foreach(var id in productIdList)
            {
                var product = await Get(db, id);
                if (product is not null)
                    result.Add(product);
            }

            return result;
        }

        public async Task<List<ProductListDTO>> ListAll(SqlConnection db) =>
            (await db.QueryAsync<ProductListDTO>(ProductSql.ListAll)).ToList();

        public async Task<List<string>> ListNamesByPromotionId(SqlConnection db, Guid promotionId) =>
            (await db.QueryAsync<string>(ProductSql.ListNamesByPromotion, new { promotionId })).ToList();

        public async Task Save(SqlConnection db, Product product)
        {
            var productModel = mapper.Map<ProductModel>(product);

            var sql = ProductSql.Insert;

            var currentId = await db.QueryFirstOrDefaultAsync<Guid?>(ProductSql.CheckIfExists, new { id = product.Id });
            if (currentId is not null && !currentId.Value.Equals(Guid.Empty))
                sql = ProductSql.Update;

            await db.ExecuteAsync(sql, productModel);
        }
    }
}

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
        private readonly IMapper mapper;

        public ProductRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task Delete(SqlConnection db, Guid id) =>
            await db.ExecuteAsync(ProductSql.Delete, new { id });

        public async Task<Product> Get(SqlConnection db, Guid id)
        {
            var model = await db.QueryFirstOrDefaultAsync<ProductModel>(ProductSql.GetById, new { id });
            if (model is null)
                return null;

            return mapper.Map<Product>(model);
        }

        public async Task<List<ProductListDTO>> ListActives(SqlConnection db) =>
            (await db.QueryAsync<ProductListDTO>(ProductSql.ListActives)).ToList();

        public async Task<List<ProductListDTO>> ListAll(SqlConnection db) =>
            (await db.QueryAsync<ProductListDTO>(ProductSql.ListAll)).ToList();

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

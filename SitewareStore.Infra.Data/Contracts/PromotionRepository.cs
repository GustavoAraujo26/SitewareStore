using AutoMapper;
using Microsoft.Data.SqlClient;
using SitewareStore.Domain.DTOs.Promotion;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Repositories;
using Dapper;
using SitewareStore.Infra.Data.Sql;
using SitewareStore.Domain.Models;

namespace SitewareStore.Infra.Data.Contracts
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly IMapper mapper;

        public PromotionRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task Delete(SqlConnection db, Guid id) =>
            await db.ExecuteAsync(PromotionSql.Delete, new { id });

        public async Task<Promotion> Get(SqlConnection db, Guid id)
        {
            var model = await db.QueryFirstOrDefaultAsync<PromotionModel>(PromotionSql.GetById, new { id });
            if (model is null)
                return null;

            return mapper.Map<Promotion>(model);
        }

        public async Task<List<PromotionListDTO>> ListActives(SqlConnection db)
        {
            var modelList = (await db.QueryAsync<PromotionModel>(PromotionSql.ListActives)).ToList();

            return mapper.Map<List<PromotionListDTO>>(modelList);
        }

        public async Task<List<PromotionListDTO>> ListAll(SqlConnection db)
        {
            var modelList = (await db.QueryAsync<PromotionModel>(PromotionSql.ListAll)).ToList();

            return mapper.Map<List<PromotionListDTO>>(modelList);
        }

        public async Task Save(SqlConnection db, Promotion promotion)
        {
            var model = mapper.Map<PromotionModel>(promotion);

            var sql = PromotionSql.Insert;

            var currentId = await db.QueryFirstOrDefaultAsync<Guid?>(PromotionSql.CheckIfExists, new { id = promotion.Id });
            if (currentId is not null && !currentId.Value.Equals(Guid.Empty))
                sql = PromotionSql.Update;

            await db.ExecuteAsync(sql, model);
        }
    }
}

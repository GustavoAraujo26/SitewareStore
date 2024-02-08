using AutoMapper;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Enums;
using SitewareStore.Domain.Models;

namespace SitewareStore.Domain.Mappers.TypeConverters.Entities
{
    /// <summary>
    /// Conversor do modelo de banco de dados de "produto" para entidade
    /// </summary>
    internal class ProductEntityTypeConverter : ITypeConverter<Tuple<ProductModel, PromotionModel>, Product>
    {
        public Product Convert(Tuple<ProductModel, PromotionModel> source, Product destination, ResolutionContext context)
        {
            var productModel = source.Item1;
            var promotionModel = source.Item2;

            return new Product(productModel.Id, productModel.Name, productModel.Price, (StatusType)productModel.Status, 
                context.Mapper.Map<Promotion>(promotionModel), productModel.CreatedAt, productModel.UpdatedAt);
        }
    }
}

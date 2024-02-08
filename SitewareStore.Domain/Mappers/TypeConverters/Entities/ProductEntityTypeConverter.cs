using AutoMapper;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Enums;
using SitewareStore.Domain.Models;

namespace SitewareStore.Domain.Mappers.TypeConverters.Entities
{
    /// <summary>
    /// Conversor do modelo de banco de dados de "produto" para entidade
    /// </summary>
    internal class ProductEntityTypeConverter : ITypeConverter<Tuple<ProductModel, Promotion>, Product>
    {
        public Product Convert(Tuple<ProductModel, Promotion> source, Product destination, ResolutionContext context)
        {
            var productModel = source.Item1;
            var promotionEntity = source.Item2;

            return new Product(productModel.Id, productModel.Name, productModel.Price, (StatusType)productModel.Status,
                promotionEntity, productModel.CreatedAt, productModel.UpdatedAt);
        }
    }
}

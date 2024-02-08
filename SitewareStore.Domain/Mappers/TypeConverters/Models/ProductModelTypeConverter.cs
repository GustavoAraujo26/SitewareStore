using AutoMapper;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Models;

namespace SitewareStore.Domain.Mappers.TypeConverters.Models
{
    /// <summary>
    /// Conversor da entidade "produto" para modelo de banco de dados
    /// </summary>
    internal class ProductModelTypeConverter : ITypeConverter<Product, ProductModel>
    {
        public ProductModel Convert(Product source, ProductModel destination, ResolutionContext context) =>
            new ProductModel
            {
                Id = source.Id,
                Name = source.Name,
                Price = source.Price,
                Status = (int)source.Status,
                PromotionId = source.PromotionApplied?.Id,
                CreatedAt = source.CreatedAt,
                UpdatedAt = source.UpdatedAt
            };
    }
}

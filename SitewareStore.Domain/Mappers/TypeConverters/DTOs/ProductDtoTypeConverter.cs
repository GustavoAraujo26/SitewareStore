using AutoMapper;
using SitewareStore.Domain.DTOs.Product;
using SitewareStore.Domain.Entities;

namespace SitewareStore.Domain.Mappers.TypeConverters.DTOs
{
    /// <summary>
    /// Conversor de lista de entidade de produto para DTO
    /// </summary>
    internal class ProductDtoTypeConverter : ITypeConverter<Product, ProductDTO>
    {
        public ProductDTO Convert(Product source, ProductDTO destination, ResolutionContext context) =>
            new ProductDTO(source.Id, source.Name, source.Price, source.Status, source.PromotionApplied?.Id);
    }
}

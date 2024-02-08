using AutoMapper;
using SitewareStore.Domain.DTOs.Cart;
using SitewareStore.Domain.Entities;

namespace SitewareStore.Domain.Mappers.TypeConverters.DTOs
{
    /// <summary>
    /// Conversor de entidade de carrinho de compras para DTO
    /// </summary>
    internal class ShoppingCartDtoTypeConverter : ITypeConverter<ShoppingCart, ShoppingCartDTO>
    {
        public ShoppingCartDTO Convert(ShoppingCart source, ShoppingCartDTO destination, ResolutionContext context) =>
            new ShoppingCartDTO(source.Id, source.Status, source.UpdatedAt, context.Mapper.Map<List<ShoppingCartItemDTO>>(source));
    }
}

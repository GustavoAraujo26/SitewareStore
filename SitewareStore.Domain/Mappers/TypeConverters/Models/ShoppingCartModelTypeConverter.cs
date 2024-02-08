using AutoMapper;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Models;

namespace SitewareStore.Domain.Mappers.TypeConverters.Models
{
    /// <summary>
    /// Conversor da entidade "carrinho de compras" para modelo de banco de dados
    /// </summary>
    internal class ShoppingCartModelTypeConverter : ITypeConverter<ShoppingCart, ShoppingCartModel>
    {
        public ShoppingCartModel Convert(ShoppingCart source, ShoppingCartModel destination, ResolutionContext context) =>
            new ShoppingCartModel
            {
                Id = source.Id,
                Status = (int)source.Status,
                InitialPrice = source.InitialPrice,
                Discounts = source.Discounts,
                FinalPrice = source.FinalPrice,
                CreatedAt = source.CreatedAt,
                UpdatedAt = source.UpdatedAt
            };
    }
}

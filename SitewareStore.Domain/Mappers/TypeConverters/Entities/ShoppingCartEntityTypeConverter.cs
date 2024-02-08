using AutoMapper;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Enums;
using SitewareStore.Domain.Models;

namespace SitewareStore.Domain.Mappers.TypeConverters.Entities
{
    /// <summary>
    /// Conversor do modelo de banco de dados de "carrinho de compras" para entidade
    /// </summary>
    internal class ShoppingCartEntityTypeConverter : ITypeConverter<Tuple<ShoppingCartModel, List<ShoppingCartItem>>, ShoppingCart>
    {
        public ShoppingCart Convert(Tuple<ShoppingCartModel, List<ShoppingCartItem>> source, ShoppingCart destination, ResolutionContext context)
        {
            var cartModel = source.Item1;
            var cartItemList = source.Item2;

            return new ShoppingCart(cartModel.Id, (ShoppingCartStatus)cartModel.Status, cartItemList, cartModel.CreatedAt, cartModel.UpdatedAt);
        }
    }
}

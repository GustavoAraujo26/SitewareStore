using AutoMapper;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Models;

namespace SitewareStore.Domain.Mappers.TypeConverters.Entities
{
    /// <summary>
    /// Conversor do modelo de banco de dados de "item do carrinho" para entidade
    /// </summary>
    internal class ShoppingCartItemEntityTypeConverter : 
        ITypeConverter<Tuple<ShoppingCartItemModel, Product>, ShoppingCartItem>
    {
        public ShoppingCartItem Convert(Tuple<ShoppingCartItemModel, Product> source, ShoppingCartItem destination, ResolutionContext context)
        {
            var cartItemModel = source.Item1;
            var productEntity = source.Item2;

            return new ShoppingCartItem(cartItemModel.Id, productEntity, cartItemModel.Quantity);
        }
    }
}

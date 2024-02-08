using AutoMapper;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Requests;

namespace SitewareStore.Domain.Mappers.TypeConverters.Requests
{
    /// <summary>
    /// Converte requisição de persistência de item de carrinho de compras em entidade
    /// </summary>
    internal class ShoppingCartItemInsertRequestTypeConverter : ITypeConverter<Tuple<AddShoppingCartItemRequest, Product>, ShoppingCartItem>
    {
        public ShoppingCartItem Convert(Tuple<AddShoppingCartItemRequest, Product> source, ShoppingCartItem destination, ResolutionContext context)
        {
            var request = source.Item1;
            var product = source.Item2;

            return new ShoppingCartItem(Guid.NewGuid(), product, request.Quantity);
        }
    }
}

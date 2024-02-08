using AutoMapper;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Models;

namespace SitewareStore.Domain.Mappers.TypeConverters.Entities
{
    /// <summary>
    /// Conversor do modelo de banco de dados de "carrinho de compras" para entidade
    /// </summary>
    internal class ShoppingCartEntityTypeConverter : ITypeConverter<Tuple<ShoppingCartModel, List<ShoppingCartItemModel>>, ShoppingCart>
    {
        public ShoppingCart Convert(Tuple<ShoppingCartModel, List<ShoppingCartItemModel>> source, ShoppingCart destination, ResolutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}

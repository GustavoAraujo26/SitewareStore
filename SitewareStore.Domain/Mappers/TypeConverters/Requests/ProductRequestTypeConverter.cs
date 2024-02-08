using AutoMapper;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Enums;
using SitewareStore.Domain.Requests;

namespace SitewareStore.Domain.Mappers.TypeConverters.Requests
{
    /// <summary>
    /// Conversor de requisição de persistência de produto para entidade
    /// </summary>
    internal class ProductRequestTypeConverter : ITypeConverter<SaveProductRequest, Product>
    {
        public Product Convert(SaveProductRequest source, Product destination, ResolutionContext context)
        {
            var newId = Guid.NewGuid();
            if (source.Id is not null && !source.Id.Value.Equals(Guid.Empty))
                newId = source.Id.Value;

            return new Product(newId, source.Name, source.Price, StatusType.Active, null, DateTime.Now, DateTime.Now);
        }
    }
}

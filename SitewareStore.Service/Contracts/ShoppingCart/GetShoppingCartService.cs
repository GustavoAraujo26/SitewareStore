using AutoMapper;
using SitewareStore.Domain.DTOs.Cart;
using SitewareStore.Domain.Repositories;
using SitewareStore.Domain.Services.ShoppingCart;
using SitewareStore.Infra.CrossCutting.Responses;
using System.Net;

namespace SitewareStore.Service.Contracts.ShoppingCart
{
    public class GetShoppingCartService : IGetShoppingCartService
    {
        private readonly IShoppingCartRepository cartRepository;
        private readonly IRepositoryBase repositoryBase;

        private readonly IMapper mapper;

        public GetShoppingCartService(IShoppingCartRepository cartRepository, IMapper mapper)
        {
            this.cartRepository = cartRepository;
            this.mapper = mapper;
        }

        public GetShoppingCartService(IShoppingCartRepository cartRepository, IRepositoryBase repositoryBase, IMapper mapper)
        {
            this.cartRepository = cartRepository;
            this.repositoryBase = repositoryBase;
            this.mapper = mapper;
        }

        public async Task<InternalResponse<ShoppingCartDTO>> Execute(Guid id)
        {
            try
            {
                if (id.Equals(Guid.Empty))
                    return InternalResponse<ShoppingCartDTO>.Custom(HttpStatusCode.BadRequest, "ID do carrinho de compras inválido.");

                using (var db = repositoryBase.CreateDbConnection())
                {
                    var currentCart = await cartRepository.Get(db, id);
                    if (currentCart is null)
                        return InternalResponse<ShoppingCartDTO>.Custom(HttpStatusCode.NotFound, "Carrinho de compras não encontrado.");

                    var dto = mapper.Map<ShoppingCartDTO>(currentCart);

                    return InternalResponse<ShoppingCartDTO>.Success(dto);
                }
            }
            catch(Exception ex)
            {
                return InternalResponse<ShoppingCartDTO>.Error(ex);
            }
        }
    }
}

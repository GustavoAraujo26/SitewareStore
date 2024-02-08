using AutoMapper;
using SitewareStore.Domain.DTOs.Cart;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Enums;
using SitewareStore.Domain.Repositories;
using SitewareStore.Domain.Services.ShoppingCart;
using SitewareStore.Infra.CrossCutting.Responses;
using System.Net;

namespace SitewareStore.Service.Contracts.ShoppingCart
{
    public class InitializeShoppingCartService : IInitializeShoppingCartService
    {
        private readonly IShoppingCartRepository cartRepository;
        private readonly IRepositoryBase repositoryBase;

        private readonly IMapper mapper;

        public InitializeShoppingCartService(IShoppingCartRepository cartRepository, 
            IRepositoryBase repositoryBase, IMapper mapper)
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
                using (var transaction = repositoryBase.CreateTransaction())
                {
                    var cart = new Domain.Entities.ShoppingCart(id, ShoppingCartStatus.Pending, 
                        new List<ShoppingCartItem>(), DateTime.Now, DateTime.Now);

                    await cartRepository.Save(db, cart);

                    var dto = mapper.Map<ShoppingCartDTO>(cart);

                    repositoryBase.CompleteTransaction(transaction);

                    return InternalResponse<ShoppingCartDTO>.Success(dto);
                }
            }
            catch (Exception ex)
            {
                return InternalResponse<ShoppingCartDTO>.Error(ex);
            }
        }
    }
}

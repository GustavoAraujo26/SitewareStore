using AutoMapper;
using SitewareStore.Domain.DTOs.Cart;
using SitewareStore.Domain.Enums;
using SitewareStore.Domain.Repositories;
using SitewareStore.Domain.Requests;
using SitewareStore.Domain.Services.ShoppingCart;
using SitewareStore.Infra.CrossCutting.Responses;
using System.Net;

namespace SitewareStore.Service.Contracts.ShoppingCart
{
    public class ChangeShoppingCartStatusService : IChangeShoppingCartStatusService
    {
        private readonly IShoppingCartRepository cartRepository;
        private readonly IRepositoryBase repositoryBase;

        private readonly IMapper mapper;

        public ChangeShoppingCartStatusService(IShoppingCartRepository cartRepository, 
            IRepositoryBase repositoryBase, IMapper mapper)
        {
            this.cartRepository = cartRepository;
            this.repositoryBase = repositoryBase;
            this.mapper = mapper;
        }

        public async Task<InternalResponse<ShoppingCartDTO>> Execute(ChangeShoppingCartStatusRequest request)
        {
            try
            {
                var validationResponse = request.Validate();
                if (!validationResponse.IsSuccess())
                    return InternalResponse<ShoppingCartDTO>.Copy(validationResponse);

                using (var db = repositoryBase.CreateDbConnection())
                using (var transaction = repositoryBase.CreateTransaction())
                {
                    var cart = await cartRepository.Get(db, request.Id);
                    if (cart is null)
                        return InternalResponse<ShoppingCartDTO>.Custom(HttpStatusCode.NotFound, "Não foi possível encontrar o carrinho de compras.");

                    if (request.Status == ShoppingCartStatus.Finished)
                        cart.Finish();
                    else if (request.Status == ShoppingCartStatus.Canceled)
                        cart.Cancel();

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

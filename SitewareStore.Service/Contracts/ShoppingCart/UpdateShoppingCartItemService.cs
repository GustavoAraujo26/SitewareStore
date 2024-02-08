using AutoMapper;
using SitewareStore.Domain.DTOs.Cart;
using SitewareStore.Domain.Repositories;
using SitewareStore.Domain.Requests;
using SitewareStore.Domain.Services.ShoppingCart;
using SitewareStore.Infra.CrossCutting.Responses;
using System.Net;

namespace SitewareStore.Service.Contracts.ShoppingCart
{
    public class UpdateShoppingCartItemService : IUpdateShoppingCartItemService
    {
        private readonly IShoppingCartRepository cartRepository;
        private readonly IRepositoryBase repositoryBase;

        private readonly IMapper mapper;

        public UpdateShoppingCartItemService(IShoppingCartRepository cartRepository, IRepositoryBase repositoryBase, IMapper mapper)
        {
            this.cartRepository = cartRepository;
            this.repositoryBase = repositoryBase;
            this.mapper = mapper;
        }

        public async Task<InternalResponse<ShoppingCartDTO>> Execute(UpdateShoppingCartItemRequest request)
        {
            try
            {
                var validationResponse = request.Validate();
                if (!validationResponse.IsSuccess())
                    return InternalResponse<ShoppingCartDTO>.Copy(validationResponse);

                using (var db = repositoryBase.CreateDbConnection())
                using (var transaction = repositoryBase.CreateTransaction())
                {
                    var cart = await cartRepository.Get(db, request.ShoppingCartId);
                    if (cart is null)
                        return InternalResponse<ShoppingCartDTO>.Custom(HttpStatusCode.NotFound, "Não foi possível encontrar o carrinho de compras.");

                    var managementResponse = ManageItems(cart, request);
                    if (!managementResponse.IsSuccess())
                        return managementResponse;

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

        private InternalResponse<ShoppingCartDTO> ManageItems(Domain.Entities.ShoppingCart cart, UpdateShoppingCartItemRequest request)
        {
            var currentItem = cart.Items.FirstOrDefault(x => x.Id.Equals(request.ShoppingCartItemId));
            if (currentItem is null)
                return InternalResponse<ShoppingCartDTO>.Custom(HttpStatusCode.NotFound, "Não foi possível encontrar o item no carrinho.");

            if (request.Quantity == 0)
                cart.RemoveItem(currentItem.Id);
            else
                cart.UpdateItemQuantity(currentItem.Id, request.Quantity);

            return InternalResponse<ShoppingCartDTO>.Custom(HttpStatusCode.OK, "Ok");
        }
    }
}

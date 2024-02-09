using SitewareStore.Domain.DTOs.Cart;
using SitewareStore.Domain.Enums;
using SitewareStore.Infra.CrossCutting.Responses;

namespace SitewareStore.Data
{
    public class UserShoppingCartService
    {
        private ShoppingCartDTO currentCart;

        public void Save(ShoppingCartDTO cart) => 
            currentCart = cart;

        public async Task<InternalResponse<ShoppingCartDTO>> GetCurrent(Func<Guid, Task<InternalResponse<ShoppingCartDTO>>> initializeCart)
        {
            if (currentCart == null || currentCart.Status != ShoppingCartStatus.Pending)
            {
                var initializationResponse = await initializeCart(Guid.NewGuid());
                if (!initializationResponse.IsSuccess())
                    return initializationResponse;

                currentCart = initializationResponse.Single;

                return InternalResponse<ShoppingCartDTO>.Success(currentCart);
            }

            return InternalResponse<ShoppingCartDTO>.Success(currentCart);
        }
    }
}

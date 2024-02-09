using AutoMapper;
using SitewareStore.Domain.DTOs.Cart;
using SitewareStore.Domain.Repositories;
using SitewareStore.Domain.Services.ShoppingCart;
using SitewareStore.Infra.CrossCutting.Responses;

namespace SitewareStore.Service.Contracts.ShoppingCart
{
    public class ListShoppingCartService : IListShoppingCartService
    {
        private readonly IShoppingCartRepository cartRepository;
        private readonly IRepositoryBase repositoryBase;

        public ListShoppingCartService(IShoppingCartRepository cartRepository, IRepositoryBase repositoryBase)
        {
            this.cartRepository = cartRepository;
            this.repositoryBase = repositoryBase;
        }

        public async Task<InternalResponse<ShoppingCartListDTO>> Execute()
        {
            try
            {
                using (var db = repositoryBase.CreateDbConnection())
                {
                    var cartList = await cartRepository.ListAll(db);

                    return InternalResponse<ShoppingCartListDTO>.Success(cartList);
                }
            }
            catch (Exception ex)
            {
                return InternalResponse<ShoppingCartListDTO>.Error(ex);
            }
        }
    }
}

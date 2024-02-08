using AutoMapper;
using SitewareStore.Domain.DTOs.Cart;
using SitewareStore.Domain.Entities;
using SitewareStore.Domain.Repositories;
using SitewareStore.Domain.Requests;
using SitewareStore.Domain.Services.ShoppingCart;
using SitewareStore.Infra.CrossCutting.Responses;
using System.Net;

namespace SitewareStore.Service.Contracts.ShoppingCart
{
    public class AddShoppingCartItemService : IAddShoppingCartItemService
    {
        private readonly IShoppingCartRepository cartRepository;
        private readonly IProductRepository productRepository;
        private readonly IRepositoryBase repositoryBase;

        private readonly IMapper mapper;

        public AddShoppingCartItemService(IShoppingCartRepository cartRepository, 
            IProductRepository productRepository, IRepositoryBase repositoryBase, IMapper mapper)
        {
            this.cartRepository = cartRepository;
            this.productRepository = productRepository;
            this.repositoryBase = repositoryBase;
            this.mapper = mapper;
        }

        public async Task<InternalResponse<ShoppingCartDTO>> Execute(AddShoppingCartItemRequest request)
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

                    var product = await productRepository.Get(db, request.ProductId);
                    if (product is null)
                        return InternalResponse<ShoppingCartDTO>.Custom(HttpStatusCode.NotFound, "Não foi possível encontrar o produto.");

                    var container = new Tuple<AddShoppingCartItemRequest, Domain.Entities.Product>(request, product);

                    var cartItem = mapper.Map<ShoppingCartItem>(container);
                    cart.AddItem(cartItem);

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

using SitewareStore.Domain.Validators;
using SitewareStore.Infra.CrossCutting.Extensions;
using SitewareStore.Infra.CrossCutting.Responses;

namespace SitewareStore.Domain.Requests
{
    /// <summary>
    /// Requisição de atualização de item do carrinho de compras
    /// </summary>
    public class UpdateShoppingCartItemRequest
    {
        /// <summary>
        /// Construtor vazio
        /// </summary>
        public UpdateShoppingCartItemRequest() { }

        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="shoppingCartId">Id do carrinho de compras</param>
        /// <param name="shoppingCartItemId">Id do item do carrinho de compras</param>
        /// <param name="quantity">Quantidade</param>
        public UpdateShoppingCartItemRequest(Guid shoppingCartId, Guid shoppingCartItemId, int quantity)
        {
            ShoppingCartId = shoppingCartId;
            ShoppingCartItemId = shoppingCartItemId;
            Quantity = quantity;
        }

        /// <summary>
        /// Id do carrinho de compras
        /// </summary>
        public Guid ShoppingCartId { get; set; }

        /// <summary>
        /// Id do item do carrinho de compras
        /// </summary>
        public Guid ShoppingCartItemId { get; set; }

        /// <summary>
        /// Quantidade
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Realiza validação das informações recebidas
        /// </summary>
        /// <returns>Container-resposta</returns>
        public InternalResponse<UpdateShoppingCartItemRequest> Validate() =>
            new ShoppingCartItemUpdateRequestValidator().Validate(this).FormatResponse<UpdateShoppingCartItemRequest>();
    }
}

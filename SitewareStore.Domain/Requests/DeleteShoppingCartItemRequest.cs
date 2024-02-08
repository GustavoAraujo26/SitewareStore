using SitewareStore.Domain.Validators;
using SitewareStore.Infra.CrossCutting.Extensions;
using SitewareStore.Infra.CrossCutting.Responses;

namespace SitewareStore.Domain.Requests
{
    /// <summary>
    /// Requisição de deleção de item do carrinho de compras
    /// </summary>
    public class DeleteShoppingCartItemRequest
    {
        /// <summary>
        /// Construtor vazio
        /// </summary>
        public DeleteShoppingCartItemRequest() { }

        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="cartId">Id do carrinho</param>
        /// <param name="cartItemId">Id do item</param>
        public DeleteShoppingCartItemRequest(Guid cartId, Guid cartItemId)
        {
            CartId = cartId;
            CartItemId = cartItemId;
        }

        /// <summary>
        /// Id do carrinho
        /// </summary>
        public Guid CartId { get; set; }

        /// <summary>
        /// Id do item
        /// </summary>
        public Guid CartItemId { get; set; }

        /// <summary>
        /// Realiza validação das informações recebidas
        /// </summary>
        /// <returns>Container-resposta</returns>
        public InternalResponse<DeleteShoppingCartItemRequest> Validate() =>
            new DeleteShoppingCartItemRequestValidator().Validate(this).FormatResponse<DeleteShoppingCartItemRequest>();
    }
}

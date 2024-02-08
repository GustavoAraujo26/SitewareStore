using SitewareStore.Domain.Enums;
using SitewareStore.Domain.Validators;
using SitewareStore.Infra.CrossCutting.Extensions;
using SitewareStore.Infra.CrossCutting.Responses;

namespace SitewareStore.Domain.Requests
{
    /// <summary>
    /// Requisição de alteração no status do carrinho de compras
    /// </summary>
    public class ChangeShoppingCartStatusRequest
    {
        /// <summary>
        /// Construtor vazio
        /// </summary>
        public ChangeShoppingCartStatusRequest() { }

        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="status">Status</param>
        public ChangeShoppingCartStatusRequest(Guid id, ShoppingCartStatus status)
        {
            Id = id;
            Status = status;
        }

        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public ShoppingCartStatus Status { get; set; }

        /// <summary>
        /// Realiza validação das informações recebidas
        /// </summary>
        /// <returns>Container-resposta</returns>
        public InternalResponse<ChangeShoppingCartStatusRequest> Validate() =>
            new ChangeShoppingCartStatusRequestValidator().Validate(this).FormatResponse<ChangeShoppingCartStatusRequest>();
    }
}

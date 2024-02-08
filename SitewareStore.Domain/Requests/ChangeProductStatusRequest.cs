using SitewareStore.Domain.Enums;
using SitewareStore.Domain.Validators;
using SitewareStore.Infra.CrossCutting.Extensions;
using SitewareStore.Infra.CrossCutting.Responses;

namespace SitewareStore.Domain.Requests
{
    /// <summary>
    /// Requisição para alteração de status de produto
    /// </summary>
    public class ChangeProductStatusRequest
    {
        /// <summary>
        /// Construtor vazio
        /// </summary>
        public ChangeProductStatusRequest() { }

        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="status">Status</param>
        public ChangeProductStatusRequest(Guid id, StatusType status)
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
        public StatusType Status { get; set; }

        /// <summary>
        /// Realiza validação das informações recebidas
        /// </summary>
        /// <returns>Container-resposta</returns>
        public InternalResponse<ChangeProductStatusRequest> Validate() =>
            new ChangeProductStatusRequestValidator().Validate(this).FormatResponse<ChangeProductStatusRequest>();
    }
}

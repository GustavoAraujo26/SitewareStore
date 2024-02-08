using SitewareStore.Domain.Enums;
using SitewareStore.Domain.Validators;
using SitewareStore.Infra.CrossCutting.Extensions;
using SitewareStore.Infra.CrossCutting.Responses;

namespace SitewareStore.Domain.Requests
{
    /// <summary>
    /// Requisição para alteração de status de promoção
    /// </summary>
    public class ChangePromotionStatusRequest
    {
        /// <summary>
        /// Construtor vazio
        /// </summary>
        public ChangePromotionStatusRequest() { }

        /// <summary>
        /// Construtor para inicializar as propriedades
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="status">Status</param>
        public ChangePromotionStatusRequest(Guid id, StatusType status)
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
        public InternalResponse<ChangePromotionStatusRequest> Validate() =>
            new ChangePromotionStatusRequestValidator().Validate(this).FormatResponse<ChangePromotionStatusRequest>();
    }
}

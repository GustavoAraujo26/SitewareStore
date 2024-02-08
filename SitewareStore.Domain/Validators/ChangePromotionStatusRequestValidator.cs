using FluentValidation;
using SitewareStore.Domain.Requests;

namespace SitewareStore.Domain.Validators
{
    /// <summary>
    /// Validador da requisição de mudança de status da promoção
    /// </summary>
    internal class ChangePromotionStatusRequestValidator : AbstractValidator<ChangePromotionStatusRequest>
    {
        /// <summary>
        /// Construtor para inicializar o validador
        /// </summary>
        public ChangePromotionStatusRequestValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage("È obrigatório informar o ID da promoção");

            RuleFor(x => x.Status).IsInEnum().WithMessage("O tipo de status selecionado não é válido.");
        }
    }
}

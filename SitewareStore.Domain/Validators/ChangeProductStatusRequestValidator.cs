using FluentValidation;
using SitewareStore.Domain.Requests;

namespace SitewareStore.Domain.Validators
{
    /// <summary>
    /// Validador da requisição de mudança de status da promoção
    /// </summary>
    internal class ChangeProductStatusRequestValidator : AbstractValidator<ChangeProductStatusRequest>
    {
        /// <summary>
        /// Construtor para inicializar o validador
        /// </summary>
        public ChangeProductStatusRequestValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage("È obrigatório informar o ID do produto");

            RuleFor(x => x.Status).IsInEnum().WithMessage("O tipo de status selecionado não é válido.");
        }
    }
}

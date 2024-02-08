using FluentValidation;
using SitewareStore.Domain.Requests;

namespace SitewareStore.Domain.Validators
{
    /// <summary>
    /// Validador da requisição de mudança de status do carrinho de compras
    /// </summary>
    internal class ChangeShoppingCartStatusRequestValidator : AbstractValidator<ChangeShoppingCartStatusRequest>
    {
        /// <summary>
        /// Construtor para inicializar o validador
        /// </summary>
        public ChangeShoppingCartStatusRequestValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage("È obrigatório informar o ID do carrinho de compras");

            RuleFor(x => x.Status).IsInEnum().WithMessage("O tipo de status selecionado não é válido.");
        }
    }
}

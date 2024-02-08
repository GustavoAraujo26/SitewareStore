using FluentValidation;
using SitewareStore.Domain.Requests;

namespace SitewareStore.Domain.Validators
{
    /// <summary>
    /// Validador da requisição de atualização de item no carrinho de compras
    /// </summary>
    internal class ShoppingCartItemUpdateRequestValidator : AbstractValidator<UpdateShoppingCartItemRequest>
    {
        /// <summary>
        /// Construtor para inicializar o validador
        /// </summary>
        public ShoppingCartItemUpdateRequestValidator()
        {
            RuleFor(x => x.ShoppingCartId).NotEqual(Guid.Empty).WithMessage("È obrigatório informar o ID do carrinho de compras");

            RuleFor(x => x.ShoppingCartItemId).NotEqual(Guid.Empty).WithMessage("È obrigatório informar o ID do item do carrinho de compras");

            RuleFor(x => x.Quantity)
                .NotNull()
                .WithMessage("A quantidade de corte não pode ser nula.");

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0)
                .WithMessage("A quantidade de corte precisa ser maior ou igual a {0}.");
        }
    }
}

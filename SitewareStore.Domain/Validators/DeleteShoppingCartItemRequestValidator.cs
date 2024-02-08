using FluentValidation;
using SitewareStore.Domain.Requests;

namespace SitewareStore.Domain.Validators
{
    /// <summary>
    /// Validador da requisição de deleção de item do carrinho de compras
    /// </summary>
    internal class DeleteShoppingCartItemRequestValidator : AbstractValidator<DeleteShoppingCartItemRequest>
    {
        /// <summary>
        /// Construtor para inicializar o validador
        /// </summary>
        public DeleteShoppingCartItemRequestValidator()
        {
            RuleFor(x => x.CartId).NotEqual(Guid.Empty).WithMessage("È obrigatório informar o ID do carrinho de compras");

            RuleFor(x => x.CartItemId).NotEqual(Guid.Empty).WithMessage("È obrigatório informar o ID do item do carrinho de compras");
        }
    }
}

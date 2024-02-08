using FluentValidation;
using SitewareStore.Domain.Requests;

namespace SitewareStore.Domain.Validators
{
    /// <summary>
    /// Validador da requisição de inserção de item no carrinho de compras
    /// </summary>
    internal class ShoppingCartItemInsertRequestValidator : AbstractValidator<AddShoppingCartItemRequest>
    {
        /// <summary>
        /// Construtor para inicializar o validador
        /// </summary>
        public ShoppingCartItemInsertRequestValidator()
        {
            RuleFor(x => x.ShoppingCartId).NotEqual(Guid.Empty).WithMessage("È obrigatório informar o ID do carrinho de compras");

            RuleFor(x => x.ProductId).NotEqual(Guid.Empty).WithMessage("È obrigatório selecionar o produto");

            RuleFor(x => x.Quantity)
                .NotNull()
                .WithMessage("A quantidade de corte não pode ser nula.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0)
                .WithMessage("A quantidade de corte precisa ser maior que {0}.");
        }
    }
}

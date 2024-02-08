using FluentValidation;
using SitewareStore.Domain.Requests;

namespace SitewareStore.Domain.Validators
{
    internal class ShoppingCartItemRequestValidator : AbstractValidator<SaveShoppingCartItemRequest>
    {
        public ShoppingCartItemRequestValidator()
        {
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

using FluentValidation;
using SitewareStore.Domain.Requests;

namespace SitewareStore.Domain.Validators
{
    /// <summary>
    /// Validador da requisição de persistência de produto
    /// </summary>
    internal class ProductRequestValidator : AbstractValidator<SaveProductRequest>
    {
        /// <summary>
        /// Construtor para inicializar o validador
        /// </summary>
        public ProductRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("O nome do produto não pode ser nulo!")
                .NotEmpty().WithMessage("O nome do produto não pode estar vazio!")
                .MaximumLength(500).WithMessage("O nome do produto deve possuir no máximo {0} caracteres.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("O preço do produto deve ser maior que {0}");
        }
    }
}

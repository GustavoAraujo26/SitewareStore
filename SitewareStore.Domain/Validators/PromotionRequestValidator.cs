using FluentValidation;
using SitewareStore.Domain.Enums;
using SitewareStore.Domain.Requests;

namespace SitewareStore.Domain.Validators
{
    /// <summary>
    /// Validador da requisição de persistência de promoção
    /// </summary>
    internal class PromotionRequestValidator : AbstractValidator<SavePromotionRequest>
    {
        /// <summary>
        /// Construtor para inicializar o validador
        /// </summary>
        public PromotionRequestValidator()
        {
            RuleFor(x => x.Observation)
                .NotNull().WithMessage("A observação da promoção não pode ser nulo!")
                .NotEmpty().WithMessage("A observação da promoção não pode estar vazio!")
                .MaximumLength(500).WithMessage("A observação da promoção deve possuir no máximo {0} caracteres.");

            RuleFor(x => x.Type).IsInEnum().WithMessage("O tipo de promoção selecionada não é válido.");

            When(x => x.Type == PromotionType.FullPriceByQuantity, () =>
            {
                ValidateForFullPriceByQuantity();
            });

            When(x => x.Type == PromotionType.PayQuantityMinusOne, () =>
            {
                ValidateForPayQuantityMinusOne();
            });

            When(x => x.Type == PromotionType.PercentageDiscount, () =>
            {
                ValidateForPercentage();
            });
        }

        /// <summary>
        /// Validações para "Valor cheio por quantidade"
        /// </summary>
        private void ValidateForFullPriceByQuantity()
        {
            RuleFor(x => x.CutQuantity)
                .NotNull()
                .WithMessage("A quantidade de corte não pode ser nula.");

            RuleFor(x => x.CutQuantity)
                .GreaterThan(0)
                .WithMessage("A quantidade de corte precisa ser maior que {0}.");

            RuleFor(x => x.Price)
                .NotNull()
                .WithMessage("O valor final não pode ser nula.");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("O valor final precisa ser maior que {0}.");
        }

        /// <summary>
        /// Validações para "Leve mais pague menos"
        /// </summary>
        private void ValidateForPayQuantityMinusOne()
        {
            RuleFor(x => x.CutQuantity)
                .NotNull()
                .WithMessage("A quantidade de corte não pode ser nula.");

            RuleFor(x => x.CutQuantity)
                .GreaterThan(0)
                .WithMessage("A quantidade de corte precisa ser maior que {0}.");
        }

        /// <summary>
        /// Validações para "Desconto por porcentagem"
        /// </summary>
        private void ValidateForPercentage()
        {
            RuleFor(x => x.Percentage)
                .NotNull()
                .WithMessage("Porcentagem não pode ser nula.");

            RuleFor(x => x.Percentage)
                .GreaterThan(0)
                .WithMessage("Porcentagem precisa ser maior que {0}.");
        }
    }
}

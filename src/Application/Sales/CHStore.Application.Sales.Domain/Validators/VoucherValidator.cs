using FluentValidation;
using CHStore.Application.Sales.Domain.Entities;

namespace CHStore.Application.Sales.Domain.Validators
{
    public class VoucherValidator : AbstractValidator<Voucher>
    {
        public VoucherValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .WithMessage("Os dados não podem ser nulos.")

                .NotEmpty()
                .WithMessage("Os dados não podem ser vazios.");

            RuleFor(x => x.Code)
                .NotNull()
                .WithMessage("O código não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O código não pode ser vazio.")
                
                .MinimumLength(3)
                .WithMessage("O código deve ter no mínimo 3 caracteres")
                
                .MaximumLength(50)
                .WithMessage("O código deve ter no máximo 50 caracteres");

            RuleFor(x => x.Active)
                .NotNull()
                .WithMessage("O indicador ativo não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O indicador ativo não pode ser vazio.");

            RuleFor(x => x.DiscountPercentage)
                .NotNull()
                .WithMessage("A porcentagem de desconto não pode ser nula.")

                .NotEmpty()
                .WithMessage("A porcentagem de desconto não pode ser vazia.")

                .LessThanOrEqualTo(0)
                .WithMessage("A porcentagem de desconto deve ser no mínimo 1%.")

                .GreaterThanOrEqualTo(101)
                .WithMessage("A porcentagem de desconto deve ser no máximo 100%.");
        }
    }
}

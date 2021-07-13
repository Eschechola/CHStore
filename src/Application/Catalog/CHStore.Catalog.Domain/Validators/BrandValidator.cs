using CHStore.Application.Core.Catalog.Domain.Entities;
using FluentValidation;


namespace CHStore.Application.Catalog.Domain.Validators
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .WithMessage("Os dados não podem ser nulos.")

                .NotEmpty()
                .WithMessage("Os dados não podem ser vazios.");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.")

                .MinimumLength(3)
                .WithMessage("O nome da marca deve ter no mínimo 3 caracteres.")

                .MaximumLength(80)
                .WithMessage("O nome da marca deve ter no máximo 80 caracteres.");
        }
    }
}

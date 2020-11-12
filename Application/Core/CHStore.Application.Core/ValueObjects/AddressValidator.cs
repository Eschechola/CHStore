using FluentValidation;

namespace CHStore.Application.Core.ValueObjects
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x)
               .NotNull()
               .WithMessage("Os dados não podem ser nulos.")

               .NotEmpty()
               .WithMessage("Os dados não podem ser vazios.");

            RuleFor(x => x.Street)
                .NotNull()
                .WithMessage("A rua não pode ser nula.")

               .NotEmpty()
               .WithMessage("A rua não pode ser vazia.")

               .MinimumLength(5)
               .WithMessage("A rua deve ter no mínimo 5 caracteres.")

               .MaximumLength(300)
               .WithMessage("A rua deve ter no máximo 300 caracteres");


            RuleFor(x => x.ZipCode)
                .NotNull()
                .WithMessage("O cep não pode ser nulo.")

               .NotEmpty()
               .WithMessage("O cep não pode ser vazio.")

               .MinimumLength(8)
               .WithMessage("O cep deve ter no mínimo 8 caracteres.")

               .MaximumLength(16)
               .WithMessage("O cep deve ter no máximo 16 caracteres");

            RuleFor(x => x.Number)
                .NotNull()
                .WithMessage("O número não pode ser nulo.")

               .NotEmpty()
               .WithMessage("O número não pode ser vazio.");
        }
    }
}

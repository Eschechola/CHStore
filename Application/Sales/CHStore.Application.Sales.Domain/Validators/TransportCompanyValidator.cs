using FluentValidation;
using CHStore.Application.Sales.Domain.Entities;
using CHStore.Application.Core.Utilities;

namespace CHStore.Application.Sales.Domain.Validators
{
    public class TransportCompanyValidator : AbstractValidator<TransportCompany>
    {
        public TransportCompanyValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .WithMessage("Os dados não podem ser nulos.")

                .NotEmpty()
                .WithMessage("Os dados não podem ser vazios.");

            RuleFor(x => x.Active)
                .NotNull()
                .WithMessage("O indicador ativo não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O indicador ativo não pode ser vazio.");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.")
                
                .MinimumLength(3)
                .WithMessage("O nome deve ter no mínimo 3 caracteres.")
                
                .MaximumLength(200)
                .WithMessage("O nome deve ter no máximo 200 caracteres.");

            RuleFor(x => x.CNPJ)
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.")

                .MinimumLength(14)
                .WithMessage("O CNPJ deve ter no mínimo 14 caracteres.")

                .MaximumLength(14)
                .WithMessage("O CNPJ deve ter no máximo 14 caracteres.")

                .Matches(RegexValidators.CNPJRegex)
                .WithMessage("O CNPJ está inválido.");

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("O email não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O email não pode ser vazio.")

                .Matches(RegexValidators.EmailRegex)
                .WithMessage("O Email está inválido.");

            RuleFor(x => x.Phone)
                .NotNull()
                .WithMessage("O telefone não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O telefone não pode ser vazio.")

                .MinimumLength(8)
                .WithMessage("O telefone deve ter no mínimo 8 caracteres.")
                
                .MaximumLength(14)
                .WithMessage("O telefone deve ter no máximo 14 caracteres.");


            RuleFor(x => x.TrackingUrl)
                .NotNull()
                .WithMessage("A url de rastreio não pode ser nula.")

                .NotEmpty()
                .WithMessage("A url de rastreio não pode ser vazia.")

                .MinimumLength(10)
                .WithMessage("A url de rastreio deve ter no mínimo 10 caracteres")

                .MaximumLength(500)
                .WithMessage("A url de rastreio deve ter no máximo 500 caracteres");

            RuleFor(x => x.SiteUrl)
                .NotNull()
                .WithMessage("A url do site não pode ser nula.")

                .NotEmpty()
                .WithMessage("A url do site não pode ser vazia.")

                .MinimumLength(10)
                .WithMessage("A url do site deve ter no mínimo 10 caracteres")

                .MaximumLength(500)
                .WithMessage("A url do site deve ter no máximo 500 caracteres");

            RuleFor(x => x.ApiUrl)
                .NotNull()
                .WithMessage("A url da api não pode ser nula.")

                .NotEmpty()
                .WithMessage("A url da api não pode ser vazia.")

                .MinimumLength(10)
                .WithMessage("A url da api deve ter no mínimo 10 caracteres")

                .MaximumLength(500)
                .WithMessage("A url da api deve ter no máximo 500 caracteres");
        }
    }
}

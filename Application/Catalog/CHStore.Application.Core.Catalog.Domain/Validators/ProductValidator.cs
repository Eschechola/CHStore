using FluentValidation;
using CHStore.Application.Core.Catalog.Domain.Entities;

namespace CHStore.Application.Catalog.Domain.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .WithMessage("Os dados não podem ser nulos.")

                .NotEmpty()
                .WithMessage("Os dados não podem ser vazios.");

            RuleFor(x => x.CategoryId)
                .NotNull()
                .WithMessage("O Id da categoria não pode ser nulo")

                .NotEmpty()
                .WithMessage("O Id da categoria não pode ser vazio")

                .LessThanOrEqualTo(0)
                .WithMessage("O Id da categoria está inválido.");

            RuleFor(x => x.BrandId)
                .NotNull()
                .WithMessage("O Id da marca não pode ser nulo")

                .NotEmpty()
                .WithMessage("O Id da marca não pode ser vazio")

                .LessThanOrEqualTo(0)
                .WithMessage("O Id da categoria está inválido.");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("O nome do produto não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O nome do produto não pode ser vazio.")

                .MinimumLength(3)
                .WithMessage("O nome do produto deve ter no mínimo 3 caracteres.")

                .MaximumLength(300)
                .WithMessage("O nome do produto deve ter no máximo 300 caracteres.");

            RuleFor(x => x.Active)
                .NotNull()
                .WithMessage("O indicador ativo não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O indicador ativo não pode ser vazio.");

            RuleFor(x => x.Description)
                .NotNull()
                .WithMessage("A descrição não pode ser nula.")

                .NotEmpty()
                .WithMessage("A descrição não pode ser vazia.")

                .MinimumLength(15)
                .WithMessage("A descrição deve ter no mínimo 15 caracteres")

                .MaximumLength(8000)
                .WithMessage("A descrição deve ter no máximo 8000 caracteres");

            RuleFor(x => x.Price)
                .NotNull()
                .WithMessage("O preço não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O preço não pode ser vazio.")

                .LessThanOrEqualTo(0)
                .WithMessage("O valor mínimo para cada produto deve ser de R$1,00")

                .GreaterThanOrEqualTo(1000001)
                .WithMessage("O valor máximo para cada produto deve ser de até R$1.000.000,00");

            RuleFor(x => x.UrlImage)
                .NotNull()
                .WithMessage("A url da imagem não pode ser nula.")

                .NotEmpty()
                .WithMessage("A url da imagem não pode ser vazia.")

                .MinimumLength(10)
                .WithMessage("A url da imagem deve ter no mínimo 10 caracteres.")

                .MaximumLength(8000)
                .WithMessage("A url da imagem deve ter no máximo 8000 caracteres");

            RuleFor(x => x.Stock)
                .NotNull()
                .WithMessage("O estoque não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O estoque não pode ser vazio.")

                .LessThanOrEqualTo(-1)
                .WithMessage("O estoque não pode ser negativo.");

            RuleFor(x => x.Length)
                .NotNull()
                .WithMessage("O comprimento não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O comprimento não pode ser vazio.")

                .LessThanOrEqualTo(0)
                .WithMessage("O comprimento não pode ser menor que 0.");

            RuleFor(x => x.Width)
                .NotNull()
                .WithMessage("A largura não pode ser nula.")

                .NotEmpty()
                .WithMessage("A largura não pode ser vazia.")

                .LessThanOrEqualTo(0)
                .WithMessage("A largura não pode ser menor que 0.");
        }
    }
}

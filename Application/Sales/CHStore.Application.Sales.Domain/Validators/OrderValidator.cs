using FluentValidation;
using CHStore.Application.Sales.Domain.Entities;

namespace CHStore.Application.Sales.Domain.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .WithMessage("Os dados não podem ser nulos.")

                .NotEmpty()
                .WithMessage("Os dados não podem ser vazios.");

            RuleFor(x => x.CustomerId)
                .NotNull()
                .WithMessage("O Id do cliente não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O Id do cliente não pode ser vazio.")
                
                .LessThanOrEqualTo(0)
                .WithMessage("O Id do cliente está inválido");


            RuleFor(x => x.PaymentMethod)
                .NotNull()
                .WithMessage("O método de pagamento não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O método de pagamento não pode ser vazio.");

            RuleFor(x => x.FreightPrice)
                .NotNull()
                .WithMessage("O preço do frete não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O preço do frete não pode ser vazio.")
                
                .LessThanOrEqualTo(0)
                .WithMessage("O preço do frete está inválido.");

            RuleFor(x => x.TotalPrice)
                .NotNull()
                .WithMessage("O preço do pedido não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O preço do pedido não pode ser vazio.")

                .LessThanOrEqualTo(0)
                .WithMessage("O preço do pedido está inválido.");

            RuleFor(x => x.ProductsPrice)
                .NotNull()
                .WithMessage("O preço dos produtos não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O preço dos produtos não pode ser vazio.")

                .LessThanOrEqualTo(0)
                .WithMessage("O preço dos produtos está inválido.");
        }
    }
}

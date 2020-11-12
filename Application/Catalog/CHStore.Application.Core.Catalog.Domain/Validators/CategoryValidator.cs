﻿using FluentValidation;
using CHStore.Application.Core.Catalog.Domain.Entities;

namespace CHStore.Application.Catalog.Domain.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .WithMessage("Os dados não podem ser nulos.")

                .NotEmpty()
                .WithMessage("Os dados não podem ser vazios.");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("O nome da categoria não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O nome da categoria não pode ser vazio.")

                .MinimumLength(3)
                .WithMessage("O nome da categoria deve ter no mínimo 3 caracteres.")

                .MaximumLength(80)
                .WithMessage("O nome da categoria deve ter no máximo 80 caracteres.");
        }
    }
}

﻿using CHStore.Application.Catalog.Domain.Validators;
using CHStore.Application.Core.Data;
using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Core.Exceptions;
using System.Collections.Generic;

namespace CHStore.Application.Core.Catalog.Domain.Entities
{
    public class Category : Entity, IAggregateRoot
    {
        #region Properties

        public string Name { get; private set; }

        //EF Properties
        public IList<Product> Products { get; private set; }

        #endregion

        #region Constructors

        public Category(string name)
        {
            Name = name;
        }

        #endregion

        #region Methods

        public void ChangeName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new DomainException("O Nome da categoria não pode ser vazio");

            Name = name;
        }

        public bool Validate()
        {
            var validator = new CategoryValidator();
            var validation = validator.Validate(this);

            if (validation.Errors.Count > 0)
                throw new DomainException(validation.Errors[0].ErrorMessage);

            return true;
        }

        #endregion
    }
}

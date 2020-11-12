using System;
using CHStore.Application.Catalog.Domain.Validators;
using CHStore.Application.Core.Data;
using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Core.Exceptions;

namespace CHStore.Application.Core.Catalog.Domain.Entities
{
    public class Product : Entity, IAggregateRoot
    {
        #region Properties

        public long CategoryId { get; private set; }
        public long BrandId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public long Stock { get; private set; }
        public bool Active { get; private set; }
        public DateTime RegisterDate { get; private set; }
        public string UrlImage { get; private set; }
        public decimal Length { get; private set; }
        public decimal Width { get; private set; }

        public Category Category { get; private set; }
        public Brand Brand { get; private set; }

        

        #endregion

        #region Constructors

        protected Product() { }

        public Product(
            long id,
            long categoryId,
            string name,
            string description,
            decimal price,
            long stock,
            bool active,
            string urlImage,
            decimal length,
            decimal width,
            Category category
        ) : base(id)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Active = active;
            RegisterDate = DateTime.Now;
            UrlImage = urlImage;
            Length = length;
            Width = width;
            Category = category;
        }

        #endregion

        #region Methods

        public void ChangeName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new DomainException("O Nome do produto não pode ser vazio");

            Name = name;
        }

        public void ChangeDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
                throw new DomainException("A Descrição do produto não pode ser vazia");

            Description = description;
        }

        public void ChangePrice(decimal price)
        {
            if (price <= 0)
                throw new DomainException("O Preço do produto não pode ser menor ou igual a 0");

            Price = price;
        }

        public void DecreaseStock(long value)
        {
            if (value <= 0)
                throw new DomainException("O valor de decremento de Estoque está inválido.");

            Stock -= value;
        }

        public void IncreaseStock(long value)
        {
            if (value <= 0)
                throw new DomainException("O valor de incremento de Estoque está inválido.");

            Stock += value;
        }

        public void Activate() => Active = true;

        public void Deactivate() => Active = false;

        public void ChangeUrlImage(string urlImage)
        {
            if (string.IsNullOrEmpty(urlImage))
                throw new DomainException("A Url da Imagem do produto não pode ser vazia");

            UrlImage = urlImage;
        }

        public void ChangeCategory(Category category)
        {
            if(category is null)
                throw new DomainException("A Categoria do produto não pode ser vazia");

            Category = category;
            CategoryId = category.Id;
        }

        public void ChangeSize(decimal lenght, decimal width)
        {
            if (lenght <= 0)
                throw new DomainException("O comprimento do produto não poder menor ou igual a zero.");

            if(width <= 0)
                throw new DomainException("A altura do produto não poder menor ou igual a zero.");

            Length = lenght;
            Width = width;
        }

        public bool HasStock(long mount = 1)
        {
            return Stock >= mount;
        }

        public bool Validate()
        {
            var validator = new ProductValidator();
            var validation = validator.Validate(this);

            if (validation.Errors.Count > 0)
                throw new DomainException(validation.Errors[0].ErrorMessage);

            return true;
        }

        #endregion
    }
}

using System;
using CHStore.Application.Catalog.Domain.Validators;
using CHStore.Application.Core.Data;
using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Core.Exceptions;
using CHStore.Core.ValueObjects;

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
        public int Stock { get; private set; }
        public bool Active { get; private set; }
        public string Slug { get; private set; }
        public DateTime RegisterDate { get; private set; }
        public string UrlImage { get; private set; }
        public Size Size { get; private set; }

        // EF Properties
        public Category Category { get; private set; }
        public Brand Brand { get; private set; }

        #endregion

        #region Constructors

        protected Product()
        {
        }

        public Product(
           long categoryId,
           string name,
           string description,
           decimal price,
           int stock,
           bool active,
           string slug,
           string urlImage,
           Size size,
           DateTime? registerDate = null)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Active = active;
            UrlImage = urlImage;
            Slug = slug;
            Size = size;
            RegisterDate = registerDate ?? DateTime.Now;
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

        public void DecreaseStock(int value)
        {
            if (value <= 0)
                throw new DomainException("O valor de decremento de Estoque está inválido.");

            Stock -= value;
        }

        public void IncreaseStock(int value)
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

        public void ChangeSize(Size size)
        {
            if (size.Length <= 0)
                throw new DomainException("O comprimento do produto não poder menor ou igual a zero.");

            if(size.Width <= 0)
                throw new DomainException("A altura do produto não poder menor ou igual a zero.");
            
            if (size.Depth <= 0)
                throw new DomainException("A profundidade do produto não poder menor ou igual a zero.");

            Size = size;
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

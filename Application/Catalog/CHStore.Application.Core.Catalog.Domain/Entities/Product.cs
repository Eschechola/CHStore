using System;
using CHStore.Application.Core.Data;
using CHStore.Application.Core.Exceptions;
using CHStore.Application.Core.Catalog.Domain.Enums;

namespace CHStore.Application.Core.Catalog.Domain.Entities
{
    public class Product : Entity
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
        public ProductSize Size { get; private set; }

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
            DateTime registerDate,
            string urlImage,
            ProductSize size,
            Category category
        ) : base(id)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Active = active;
            RegisterDate = registerDate;
            UrlImage = urlImage;
            Size = size;
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

        public void ChangeSize(ProductSize size) => Size = size;

        public bool HasStock(long mount)
        {
            return Stock >= mount;
        }

        #endregion
    }
}

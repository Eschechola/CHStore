using CHStore.Database.ValueObjects;
using System;
using System.Collections.Generic;

namespace CHStore.Database.Entities
{
    public class Product : Entity
    {
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

        public Category Category { get; private set; }
        public Brand Brand { get; private set; }
        public IList<OrderProduct> OrderProducts { get; private set; }

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
    }
}

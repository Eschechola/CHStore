using System;
using CHStore.Core.ValueObjects;

namespace CHStore.Application.Catalog.ApplicationServices.DTO
{
    public class ProductDTO
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public long BrandId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool Active { get; set; }
        public string Slug { get; set; }
        public DateTime RegisterDate { get; set; }
        public string UrlImage { get; set; }
        public Size Size { get; set; }
        public CategoryDTO Category { get; private set; }
        public BrandDTO Brand { get; private set; }
    }
}

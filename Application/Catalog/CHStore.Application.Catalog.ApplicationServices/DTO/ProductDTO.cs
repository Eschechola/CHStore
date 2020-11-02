using System;
using CHStore.Application.Core.Catalog.Domain.Enums;

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
        public long Stock { get; set; }
        public bool Active { get; set; }
        public DateTime RegisterDate { get; set; }
        public string UrlImage { get; set; }
        public ProductSize Size { get; set; }
        public CategoryDTO Category { get; set; }
        public BrandDTO Brand { get; set; }

    }
}

﻿using System;

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
        public string Slug { get; set; }
        public bool Active { get; set; }
        public DateTime RegisterDate { get; set; }
        public string UrlImage { get; set; }
        public decimal Lenght { get; set; }
        public decimal Width { get; set; }
        public CategoryDTO Category { get; set; }
        public BrandDTO Brand { get; set; }

    }
}

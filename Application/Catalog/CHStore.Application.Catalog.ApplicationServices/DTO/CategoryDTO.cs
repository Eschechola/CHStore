using System.Collections.Generic;

namespace CHStore.Application.Catalog.ApplicationServices.DTO
{
    public class CategoryDTO
    {
        public string Name { get; set; }

        public IList<ProductDTO> Products { get; set; }
    }
}

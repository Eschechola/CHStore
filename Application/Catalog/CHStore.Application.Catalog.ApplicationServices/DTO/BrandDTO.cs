using System.Collections.Generic;

namespace CHStore.Application.Catalog.ApplicationServices.DTO
{
    public class BrandDTO
    {
        public string Name { get; set; }

        public IList<ProductDTO> Products { get; set; }

    }
}

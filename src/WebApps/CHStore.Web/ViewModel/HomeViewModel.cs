using System.Collections.Generic;
using CHStore.Application.Catalog.ApplicationServices.DTO;

namespace CHStore.Web.ViewModel
{
    public class HomeViewModel
    {
        public IList<ProductDTO> LastProducts { get; set; }
        public IList<ProductDTO> MostSellingProducts  { get; set; }
    }
}

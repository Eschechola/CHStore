using System.Collections.Generic;

namespace CHStore.Application.Sales.ApplicationServices.DTO
{
    public class CustomerDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public IList<OrderDTO> Orders { get; set; }
    }
}

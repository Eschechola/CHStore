using System;

namespace CHStore.Application.Sales.ApplicationServices.DTO
{
    public class VoucherDTO
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public decimal DiscountPercentage { get; set; }
        public bool Active { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }

        public OrderDTO Order { get; set; }
    }
}

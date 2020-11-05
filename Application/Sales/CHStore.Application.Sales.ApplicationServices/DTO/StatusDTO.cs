using System;
using CHStore.Application.Sales.Domain.Enums;

namespace CHStore.Application.Sales.ApplicationServices.DTO
{
    public class StatusDTO
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime DateModified { get; set; }

        public OrderDTO Order { get; set; }
    }
}

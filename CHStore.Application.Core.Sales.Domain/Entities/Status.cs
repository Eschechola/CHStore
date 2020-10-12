using System;
using CHStore.Application.Core.Data;
using CHStore.Application.Sales.Domain.Enums;

namespace CHStore.Application.Sales.Domain.Entities
{
    public class Status : Entity
    {
        public DateTime DateModified { get; private set; }
        public OrderStatus OrderStatus { get; private set; }

        public Status(DateTime dateModified, OrderStatus orderStatus)
        {
            DateModified = dateModified;
            OrderStatus = orderStatus;
        }

    }
}

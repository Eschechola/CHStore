using CHStore.Database.Enums;
using System;

namespace CHStore.Database.Entities
{
    public class Status : Entity
    {
        public long OrderId { get; private set; }
        public DateTime DateModified { get; private set; }
        public OrderStatus OrderStatus { get; private set; }

        public Order Order { get; private set; }

        public Status(
            long orderId,
            DateTime dateModified,
            OrderStatus orderStatus)
        {
            OrderId = orderId;
            DateModified = dateModified;
            OrderStatus = orderStatus;
        }
    }
}

using CHStore.Database.Enums;

namespace CHStore.Database.Entities
{
    public class Status : Entity
    {
        public long OrderId { get; private set; }
        public OrderStatus OrderStatus { get; private set; }

        public Order Order { get; private set; }

        public Status(
            long orderId,
            OrderStatus orderStatus)
        {
            OrderId = orderId;
            OrderStatus = orderStatus;
        }
    }
}

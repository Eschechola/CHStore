namespace CHStore.Database.Entities
{
    public class OrderProduct : Entity
    {
        public long OrderId { get; private set; }
        public long ProductId { get; private set; }
        public int Mount { get; private set; }

        public Order Order { get; private set; }
        public Product Product { get; private set; }

        public OrderProduct(long orderId, long productId, int mount)
        {
            OrderId = orderId;
            ProductId = productId;
            Mount = mount;
        }
    }
}

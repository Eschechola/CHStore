using CHStore.Application.Core.Data;

namespace CHStore.Application.Sales.Domain.Entities
{
    public class OrderProduct : Entity
    {
        public long OrderId { get; set; }
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

        public decimal GetPriceOrderProduct()
        {
            return Product.Price * Mount;
        }
    }
}

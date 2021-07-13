using CHStore.Application.Core.Data;

namespace CHStore.Application.Sales.Domain.Entities
{
    public class OrderProduct : Entity
    {
        #region Properties

        public long OrderId { get; set; }
        public long ProductId { get; private set; }
        public int Mount { get; private set; }

        //Ef Properties
        public Order Order { get; private set; }
        public Product Product { get; private set; }

        #endregion

        #region Constructors

        protected OrderProduct()
        {
        }

        public OrderProduct(long orderId, long productId, int mount)
        {
            OrderId = orderId;
            ProductId = productId;
            Mount = mount;
        }

        #endregion

        #region Methods

        public decimal GetPriceOrderProduct()
        {
            return Product.Price * Mount;
        }

        #endregion
    }
}

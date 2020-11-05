namespace CHStore.Application.Sales.ApplicationServices.DTO
{
    public class OrderProductDTO
    {
        public long Id { get; set; }
        public long OrderId { get;set; }
        public long ProductId { get; set; }
        public int Mount { get; set; }

        public OrderDTO Order { get; set; }
        public ProductDTO Product { get; set; }
    }
}

using System;

namespace CHStore.Application.Core.Filters
{
    public class SearchOrderFilter
    {
        public long OrderId { get; set; }
        public long CustomerId { get; set; }
        public int Status { get; set; }
        public DateTime? RequestDate { get; set; }
        public decimal InitialPrice { get; set; }
        public decimal FinalPrice { get; set; }
    }
}

using System;

namespace CHStore.Application.Core.Filters
{
    public class SearchVoucherFilter
    {
        public long VoucherId { get; set; }
        public string Code { get; set; }
        public DateTime? InitialDate { get; set; }
        public DateTime? FinalDate { get; set; }
    }
}

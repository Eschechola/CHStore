namespace CHStore.Application.Core.Filters
{
    public class SearchProductFilter
    {
        public long ProductId { get; set; }
        public long CategoryId { get; set; }
        public long BrandId { get; set; }
        public string Name { get; set; }
        public bool OnlyActives { get; set; }
        public decimal MinimumPrice { get; set; }
        public decimal MaximumPrice { get; set; }
    }
}

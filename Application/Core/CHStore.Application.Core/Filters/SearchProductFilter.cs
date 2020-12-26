namespace CHStore.Application.Core.Filters
{
    public class SearchProductFilter
    {
        public long ProductId { get; private set; }
        public long CategoryId { get; private set; }
        public long BrandId { get; private set; }
        public string Name { get; private set; }
        public bool OnlyActives { get; private set; }
        public decimal MinimumPrice { get; private set; }
        public decimal MaximumPrice { get; private set; }
        public int MinimumStock { get; private set; }
        public int MountOfProducts { get; private set; }


        public SearchProductFilter(
            long productId = 0,
            long categoryId = 0,
            long brandId = 0,
            string name = "",
            bool onlyActives = false,
            decimal minimumPrice = 0,
            decimal maximumPrice = decimal.MaxValue,
            int minimumStock = 0,
            int mountOfProducts = 0
        )
        {
            ProductId = productId;
            CategoryId = categoryId;
            BrandId = brandId;
            Name = name;
            OnlyActives = onlyActives;
            MinimumPrice = minimumPrice;
            MaximumPrice = maximumPrice;
            MinimumStock = minimumStock;
            MountOfProducts = mountOfProducts;
        }
    }
}

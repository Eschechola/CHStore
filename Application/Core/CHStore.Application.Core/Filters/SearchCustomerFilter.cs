namespace CHStore.Application.Core.Filters
{
    public class SearchCustomerFilter
    {
        public long CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool OnlyActives { get; set; }
        public string CPFOrCNPJ { get; set; }
    }
}

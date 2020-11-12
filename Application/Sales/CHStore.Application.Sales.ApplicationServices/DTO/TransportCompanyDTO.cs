using CHStore.Application.Core.ValueObjects;

namespace CHStore.Application.Sales.ApplicationServices.DTO
{
    public class TransportCompanyDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string SiteUrl { get; set; }
        public string TrackingUrl { get; set; }
        public string ApiUrl { get; set; }
        public bool Active { get; set; }


        public Address Address { get; set; }
    }
}

using CHStore.Database.ValueObjects;

namespace CHStore.Database.Entities
{
    public class TransportCompany : Entity
    {
        public string Name { get; private set; }
        public string CNPJ { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string SiteUrl { get; private set; }
        public string TrackingUrl { get; private set; }
        public string ApiUrl { get; private set; }
        public bool Active { get; private set; }


        public Address Address { get; private set; }
        public Order Order { get; private set; }


        protected TransportCompany()
        {
        }

        public TransportCompany(
            string name,
            string cnpj,
            string email,
            string phone,
            string siteUrl,
            string trackingUrl,
            string apiUrl,
            bool active,
            Address address)
        {
            Name = name.ToUpper();
            CNPJ = cnpj;
            Email = email.ToUpper();
            Phone = phone;
            SiteUrl = siteUrl.ToLower();
            TrackingUrl = trackingUrl.ToLower();
            ApiUrl = apiUrl.ToLower();
            Active = active;
            Address = address;
        }
    }
}

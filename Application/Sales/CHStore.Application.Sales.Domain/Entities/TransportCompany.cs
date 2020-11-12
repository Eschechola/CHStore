using CHStore.Application.Core.Data;
using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Core.Exceptions;
using CHStore.Application.Core.ValueObjects;

namespace CHStore.Application.Sales.Domain.Entities
{
    public class TransportCompany : Entity, IAggregateRoot
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


        protected TransportCompany(){}

        public TransportCompany
        (
            string name,
            string cnpj,
            string email,
            string phone,
            string SiteUrl,
            string trackingUrl,
            string apiUrl,
            bool active,
            Address address
        )
        {
            Name = name.ToUpper();
            CNPJ = cnpj;
            Email = email.ToUpper();
            Phone = phone;
            SiteUrl = SiteUrl.ToLower();
            TrackingUrl = trackingUrl.ToLower();
            ApiUrl = apiUrl.ToLower();
            Active = active;
            Address = address;
        }

        public void ChangeName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new DomainException("O Nome da tranportadora não pode ser vazia");

            Name = name;
        }

        public void ChangeSiteUrl(string SiteUrl)
        {
            if (string.IsNullOrEmpty(SiteUrl))
                throw new DomainException("A URL do site da tranportadora não pode ser vazio");

            Name = SiteUrl;
        }

        public void ChangeTrackingUrl(string trackingUrl)
        {
            if (string.IsNullOrEmpty(trackingUrl))
                throw new DomainException("A URL de rastreio da tranportadora não pode ser vazia");

            TrackingUrl = trackingUrl;
        }

        public void ChangeApiUrl(string apiUrl)
        {
            if (string.IsNullOrEmpty(apiUrl))
                throw new DomainException("A URL de api da tranportadora não pode ser vazia");

            ApiUrl = apiUrl;
        }

        public void ActivateTransportCompany() => Active = true;
        public void DeactivateTransportCompany() => Active = false;

        public bool Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}

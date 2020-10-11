﻿using CHStore.Application.Core.Data;
using CHStore.Application.Core.Exceptions;
using CHStore.Application.Core.ValueObjects;

namespace CHStore.Application.Sales.Domain.Entities
{
    public class TransportCompany : Entity
    {
        public string Name { get; private set; }
        public string CNPJ { get; private set; }
        public string WebSiteUrl { get; set; }
        public string TrackingUrl { get; private set; }
        public string ApiUrl { get; private set; }
        public Address Address { get; private set; }

        public TransportCompany(
            string name,
            string cnpj,
            string webSiteUrl,
            string trackingUrl,
            string apiUrl,
            Address address
        )
        {
            Name = name;
            CNPJ = cnpj;
            WebSiteUrl = webSiteUrl;
            TrackingUrl = trackingUrl;
            ApiUrl = apiUrl;
            Address = address;
        }


        public void ChangeName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new DomainException("O Nome da tranportadora não pode ser vazia");

            Name = name;
        }

        public void ChangeWebSiteUrl(string webSiteUrl)
        {
            if (string.IsNullOrEmpty(webSiteUrl))
                throw new DomainException("A URL do site da tranportadora não pode ser vazio");

            Name = webSiteUrl;
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
    }
}

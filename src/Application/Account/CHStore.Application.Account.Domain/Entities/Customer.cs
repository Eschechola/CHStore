using System;
using CHStore.Application.Core.ValueObjects;
using CHStore.Application.Accounts.Domain.Enums;
using CHStore.Application.Core.Data.Interfaces;

namespace CHStore.Application.Account.Domain.Entities
{
    public class Customer : Account, IAggregateRoot
    {
        public bool Active { get; private set; }
        public string CPF { get; private set; }
        public string CNPJ { get; private set; }
        public CustomerDocumentType DocumentType { get; private set; }

        protected Customer(){}

        public Customer(
            string name,
            string email,
            string password,
            DateTime registerDate,
            Address address,
            CustomerDocumentType documentType,
            string cpf = "",
            string cnpj = ""
        ) : base(name, email, password, address)
        {
            CPF = cpf;
            CNPJ = cnpj;
            DocumentType = documentType;
        }

        public void ActiveCustomer() => Active = true;
        public void DeactiveCustomer() => Active = false;

        public bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}

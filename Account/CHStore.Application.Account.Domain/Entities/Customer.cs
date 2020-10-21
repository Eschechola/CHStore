using System;
using CHStore.Application.Core.ValueObjects;
using CHStore.Application.Users.Domain.Enums;

namespace CHStore.Application.Account.Domain.Entities
{
    public class Customer : Account
    {
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
    }
}

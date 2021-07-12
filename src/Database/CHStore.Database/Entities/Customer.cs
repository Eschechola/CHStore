using CHStore.Application.Accounts.Domain.Enums;
using CHStore.Database.ValueObjects;
using System.Collections.Generic;

namespace CHStore.Database.Entities
{
    public class Customer : Account
    {
        public string CPF { get; private set; }
        public string CNPJ { get; private set; }
        public string CNH { get; private set; }
        public CustomerDocumentType DocumentType { get; private set; }

        public IList<Order> Orders { get; private set; }

        protected Customer()
        {
        }

        public Customer(
            string name,
            string email,
            string password,
            CustomerDocumentType documentType,
            Address address,
            string cpf = "",
            string cnpj = "",
            string cnh = "")
            : base(name, email, password, address)
        {
            CPF = cpf;
            CNPJ = cnpj;
            CNH = cnh;
            DocumentType = documentType;
        }
    }
}

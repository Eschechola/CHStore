using System;
using CHStore.Application.Core.ValueObjects;
using CHStore.Application.Accounts.Domain.Enums;
using CHStore.Application.Core.Data.Interfaces;

namespace CHStore.Application.Account.Domain.Entities
{
    public class Customer : Account, IAggregateRoot
    {
        #region Properties

        public string CPF { get; private set; }
        public string CNPJ { get; private set; }
        public string CNH { get; private set; }
        public CustomerDocumentType DocumentType { get; private set; }

        #endregion

        #region Constructors

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

        #endregion

        #region Methods

        public bool Validate()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

using System;
using CHStore.Application.Core.Data;
using CHStore.Application.Core.Exceptions;
using CHStore.Application.Core.ValueObjects;
using CHStore.Application.Users.Domain.Enums;

namespace CHStore.Application.Users.Domain.Entities
{
    public class Customer : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime RegisterDate { get; private set; }
        public Address Address { get; private set; }
        public string CPF { get; private set; }
        public string CNPJ { get; private set; }
        public CustomerDocumentType DocumentType { get; private set; }

        public Customer(
            string name,
            string email,
            string password,
            DateTime registerDate,
            Address address,
            CustomerDocumentType documentType,
            string cpf = "",
            string cnpj = ""
        )
        {
            Name = name.ToUpper();
            Email = email.ToUpper();
            Password = password.ToUpper();
            RegisterDate = registerDate;
            Address = address;
            CPF = cpf;
            CNPJ = cnpj;
            DocumentType = documentType;
        }

        public void ChangeName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new DomainException("O nome não pode ser vazio");

            Name = name.ToUpper();
        }

        public void ChangeEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new DomainException("O email não pode ser vazio");

            Email = email.ToUpper();
        }

        public void ChangePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new DomainException("A senha não pode ser vazia");

            Password = password;
        }

        public void ChangeDocument(string document)
        {
            if (string.IsNullOrEmpty(document))
                throw new DomainException("O CPF ou CNPJ não pode ser vazio");

            if (DocumentType == CustomerDocumentType.CPF)
                CPF = document;
            else
                CNPJ = document;
        }
    }
}

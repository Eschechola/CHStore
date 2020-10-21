using System;
using CHStore.Application.Core.Data;
using CHStore.Application.Core.Exceptions;
using CHStore.Application.Core.ValueObjects;

namespace CHStore.Application.Account.Domain.Entities
{
    public class Account : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime RegisterDate { get; private set; }
        public Address Address { get; private set; }

        
        protected Account() { }

        public Account(
            string name,
            string email,
            string password,
            Address address
        )
        {
            Name = name .ToUpper();
            Email = email.ToUpper();
            Password = password;
            Address = address;
        }

        public void ChangeName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new DomainException("O nome não pode ser vazio");

            Name = name.ToUpper();
        }

        public void ChangePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new DomainException("A senha não pode ser vazia");

            Password = password;
        }

        public void ChangeEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new DomainException("O email não pode ser vazio");

            Email = email.ToUpper();
        }

    }
}

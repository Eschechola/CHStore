﻿using System;
using CHStore.Application.Core.Data;
using CHStore.Application.Core.Exceptions;
using CHStore.Application.Core.ValueObjects;

namespace CHStore.Application.Account.Domain.Entities
{
    public abstract class Account : Entity
    {
        #region Propeties

        public string Name { get; private set; }
        public string Email { get; private set; }
        public bool Active { get; private set; }
        public string Password { get; private set; }
        public DateTime RegisterDate { get; private set; }
        public Address Address { get; private set; }

        #endregion

        #region Constructors

        protected Account()
        {
        }

        public Account(
            string name,
            string email,
            string password,
            Address address,
            DateTime? registerDate = null,
            bool active = true)
        {
            Name = name.ToUpper();
            Email = email.ToUpper();
            Password = password;
            Address = address;
            RegisterDate = registerDate ?? DateTime.Now;
            Active = active;
        }

        #endregion

        #region Methods

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

        public void ActiveAccount() 
            => Active = true;
        public void DeactiveAccount() 
            => Active = false;

        #endregion
    }
}

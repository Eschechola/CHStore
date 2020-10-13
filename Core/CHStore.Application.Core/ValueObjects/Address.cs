using System;
using CHStore.Application.Core.Data;
using CHStore.Application.Core.Exceptions;

namespace CHStore.Application.Core.ValueObjects
{
    public class Address
    {
        public string Number { get; private set; }
        public string Street { get; private set; }
        public string ZipCode { get; private set; }
        public string Complement { get; private set; }
        public TimeSpan OpeningTime { get; private set; }
        public TimeSpan ClosingTime { get; private set; }


        protected Address(){}

        public Address(
            string number,
            string street,
            string zipCode,
            TimeSpan openingTime,
            TimeSpan closingTime,
            string complement = ""
        )
        {
            Number = number;
            Street = street;
            ZipCode = zipCode;
            Complement = complement;
            OpeningTime = openingTime;
            ClosingTime = closingTime;
        }

        public void ChangeNumber(string number)
        {
            if (string.IsNullOrEmpty(number))
                throw new DomainException("O Número da transportadora é inválido!");

            Number = number;
        }

        public void ChangeStreet(string street)
        {
            if (string.IsNullOrEmpty(street))
                throw new DomainException("A Rua não pode ser vazia.");

            Street = street;
        }

        public void ChangeZipCode(string zipCode)
        {
            if(string.IsNullOrEmpty(zipCode))
                throw new DomainException("O CEP não pode ser vazio.");

            ZipCode = zipCode;
        }

        public void ChangeComplement(string complement)
        {
            if (string.IsNullOrEmpty(complement))
                throw new DomainException("O Complemento não pode ser vazio.");

            Complement = complement;
        }

        public void ChangeOpeningTime(TimeSpan openingTime) => OpeningTime = openingTime;

        public void ChangeClosingTime(TimeSpan closingTime) => ClosingTime = closingTime;
    }
}

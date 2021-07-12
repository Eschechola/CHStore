using System;

namespace CHStore.Database.ValueObjects
{
    public class Address
    {
        public string Number { get; private set; }
        public string Street { get; private set; }
        public string ZipCode { get; private set; }
        public string Complement { get; private set; }
        public TimeSpan OpeningTime { get; private set; }
        public TimeSpan ClosingTime { get; private set; }

        protected Address()
        {
        }

        public Address(
            string number,
            string street,
            string zipCode,
            TimeSpan openingTime = new TimeSpan(),
            TimeSpan closingTime = new TimeSpan(),
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
    }
}

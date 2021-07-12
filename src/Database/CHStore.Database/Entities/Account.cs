using CHStore.Database.ValueObjects;
using System;

namespace CHStore.Database.Entities
{
    public abstract class Account : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }
        public DateTime RegisterDate { get; private set; }
        public Address Address { get; private set; }


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
    }
}

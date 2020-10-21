using System.Collections.Generic;
using CHStore.Application.Core.ValueObjects;

namespace CHStore.Application.Account.Domain.Entities
{
    public class Employee : Account
    {

        public string Username { get; private set; }
        public string CPF { get; private set; }

        public IList<Permission> Permissions { get; private set; }

        protected Employee(){}

        public Employee(
            string name,
            string username,
            string email,
            string password,
            string cpf,
            Address address,
            IList<Permission> permissions
        ) : base(name, email, password, address)
        {
            Username = username;
            CPF = cpf;
        }

        public void AddPermission(Permission permission) => Permissions.Add(permission);
        public void RemovePermission(Permission permission) => Permissions.Remove(permission);
    }
}

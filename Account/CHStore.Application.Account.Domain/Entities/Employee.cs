using CHStore.Application.Core.Exceptions;
using System.Collections.Generic;

namespace CHStore.Application.Users.Domain.Entities
{
    public class Employee
    {
        public string Name { get; private set; }
        public string Username { get; private set; }
        public string PersonalEmail { get; private set; }
        public string EnterpriseEmail { get; private set; }
        public string Password { get; private set; }
        public string CPF { get; private set; }

        public IList<EmployeePermission> Permissions { get; private set; }

        public Employee(
            string name,
            string username,
            string personalEmail,
            string enterpriseEmail,
            string password,
            string cpf,
            IList<EmployeePermission> permissions
        )
        {
            Name = name;
            Username = username;
            PersonalEmail = personalEmail;
            EnterpriseEmail = enterpriseEmail;
            Password = password;
            CPF = cpf;
            Permissions = permissions;
        }

        public void ChangeName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new DomainException("O nome não pode ser vazio");

            Name = name.ToUpper();
        }

        public void ChangePersonalEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new DomainException("O email pessoal não pode ser vazio");

            PersonalEmail = email.ToUpper();
        }

        public void ChangePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new DomainException("A senha não pode ser vazia");

            Password = password;
        }

        public void AddPermission(EmployeePermission permission) => Permissions.Add(permission);
        public void RemovePermission(EmployeePermission permission) => Permissions.Remove(permission);
    }
}

using CHStore.Database.ValueObjects;
using System.Collections.Generic;

namespace CHStore.Database.Entities
{
    public class Employee : Account
    {
        public string CPF { get; private set; }
        public string Username { get; private set; }
        
        private readonly List<EmployeePermission> _employeePermissions;
        public IReadOnlyCollection<EmployeePermission> EmployeePermissions => _employeePermissions;

        protected Employee()
        {
            _employeePermissions = new List<EmployeePermission>();
        }

        public Employee(
            string name,
            string username,
            string email,
            string password,
            string cpf,
            Address address,
            List<EmployeePermission> permissions = null
        ) : base(name, email, password, address)
        {
            Username = username;
            CPF = cpf;
            _employeePermissions = permissions;
        }
    }
}

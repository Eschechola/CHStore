using System.Collections.Generic;
using System.Linq;
using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Core.ValueObjects;

namespace CHStore.Application.Account.Domain.Entities
{
    public class Employee : Account, IAggregateRoot
    {
        public bool Active { get; private set; }
        public string Username { get; private set; }
        public string CPF { get; private set; }


        private readonly List<EmployeePermission> _employeePermissions;

        public IReadOnlyCollection<EmployeePermission> EmployeePermissions => _employeePermissions;

        protected Employee(){}

        public Employee(
            string name,
            string username,
            string email,
            string password,
            string cpf,
            Address address,
            List<EmployeePermission> permissions
        ) : base(name, email, password, address)
        {
            Username = username;
            CPF = cpf;
            _employeePermissions = permissions;
        }

        public void AddPermission(EmployeePermission employeePermission)
        {
            var permissionExists = _employeePermissions
                                   .Where(
                                            x =>
                                                x.EmployeeId == employeePermission.EmployeeId &&
                                                x.PermissionId == employeePermission.PermissionId
                                    )
                                   .FirstOrDefault();

            if (permissionExists == null)
                _employeePermissions.Add(employeePermission);
        }
        public void RemovePermission(EmployeePermission employeePermission)
        {
            var permissionExists = _employeePermissions
                                   .Where(
                                            x =>
                                                x.EmployeeId == employeePermission.EmployeeId &&
                                                x.PermissionId == employeePermission.PermissionId
                                    )
                                   .FirstOrDefault();

            if (permissionExists == null)
                _employeePermissions.Remove(employeePermission);
        }

        public void ActiveEmployee() => Active = true;

        public void DeactivateEmployee() => Active = false;

        public bool Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}

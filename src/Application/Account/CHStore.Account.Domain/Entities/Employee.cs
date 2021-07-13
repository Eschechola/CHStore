using System.Collections.Generic;
using System.Linq;
using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Core.ValueObjects;

namespace CHStore.Application.Account.Domain.Entities
{
    public class Employee : Account, IAggregateRoot
    {
        #region Properties

        public string CPF { get; private set; }
        public string Username { get; private set; }

        private readonly List<EmployeePermission> _employeePermissions;
        public IReadOnlyCollection<EmployeePermission> EmployeePermissions => _employeePermissions;

        #endregion

        #region Constructors

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

        #endregion

        #region Methods

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

        public bool Validate()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}

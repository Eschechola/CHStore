﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CHStore.Application.Account.Domain.Entities;

namespace CHStore.Application.Account.DomainServices.Interfaces
{
    public interface IAccountDomainService : IDisposable
    {
        Task<Employee> CreateEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<bool> AuthenticateEmployee(string login, string password);
        Task AddEmployeePermission(long employeeId, Permission permission);
        Task RemoveEmployeePermission(long employeeId, Permission permission);
        Task<IList<EmployeePermission>> GetEmployeePermissions(long employeeId);

        Task<Customer> CreateCustomer(Customer customer);
        Task<Customer> UpdateCustomer(Customer customer);
        Task<bool> AuthenticateCustomer(string login, string password);

        Task<IList<Permission>> GetAllPermissions();
    }
}

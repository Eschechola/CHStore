using System.Collections.Generic;
using CHStore.Application.Account.Domain.Entities;

namespace CHStore.Application.Account.DomainServices.Interfaces
{
    public interface IAccountDomainService
    {
        Employee CreateEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        bool AuthenticateEmployeeByUsername(string username, string password);
        bool AuthenticateEmployeeByCPF(string cpf, string password);
        bool AuthenticateEmployeeByEmail(string email, string password);
        IList<Employee> SearchEmployee(string term);
        void AddEmployeePermission(long employeeId, Permission permission);
        void RemoveEmployeePermission(long employeeId, Permission permission);
        IList<EmployeePermission> GetEmployeePermissions(long employeeId);

        Customer CreateCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        bool AuthenticateCustomerByEmail(string email, string password);
        IList<Customer> SearchCustomer(string term);

        IList<Permission> GetAllPermissions();
    }
}

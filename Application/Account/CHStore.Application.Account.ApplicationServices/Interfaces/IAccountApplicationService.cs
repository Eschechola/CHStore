using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CHStore.Application.Account.ApplicationServices.DTO;
using CHStore.Application.Core.Filters;

namespace CHStore.Application.Account.ApplicationServices.Interfaces
{
    public interface IAccountApplicationService : IDisposable
    {
        Task<EmployeeDTO> CreateEmployee(EmployeeDTO employeeDTO);
        Task<EmployeeDTO> UpdateEmployee(EmployeeDTO employeeDTO);
        Task<bool> AuthenticateEmployee(string login, string password);
        Task<IList<EmployeeDTO>> SearchEmployee(SearchEmployeeFilter searchFilter);
        Task AddEmployeePermission(long employeeId, PermissionDTO permissionDTO);
        Task RemoveEmployeePermission(long employeeId, PermissionDTO permissionDTO);
        Task<IList<EmployeePermissionDTO>> GetEmployeePermissions(long employeeId);

        Task<CustomerDTO> CreateCustomer(CustomerDTO customerDTO);
        Task<CustomerDTO> UpdateCustomer(CustomerDTO customerDTO);
        Task<bool> AuthenticateCustomer(string login, string password);
        Task<IList<CustomerDTO>> SearchCustomer(SearchCustomerFilter searchFilter);

        Task<IList<PermissionDTO>> GetAllPermissions();
    }
}

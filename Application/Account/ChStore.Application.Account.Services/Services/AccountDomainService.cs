using System.Collections.Generic;
using System.Threading.Tasks;
using CHStore.Application.Account.Domain.Entities;
using CHStore.Application.Account.DomainServices.Interfaces;
using CHStore.Application.Account.Infra.Interfaces;
using CHStore.Application.Core.Exceptions;
using CHStore.Application.Core.ExtensionMethods;
using CHStore.Application.Core.Filters;

namespace CHStore.Application.Account.DomainServices
{
    public class AccountDomainService : IAccountDomainService
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IPermissionRepository _permissionRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public AccountDomainService(
            ICustomerRepository customerRepository,
            IPermissionRepository permissionRepository,
            IEmployeeRepository employeeRepository
        )
        {
            _customerRepository = customerRepository;
            _permissionRepository = permissionRepository;
            _employeeRepository = employeeRepository;
        }

        #region Employee

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            await _employeeRepository.Add(employee);
            await _employeeRepository.UnitOfWork.Commit();

            return employee;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            await _employeeRepository.Update(employee);
            await _employeeRepository.UnitOfWork.Commit();

            return employee;
        }

        public async Task<bool> AuthenticateEmployee(string login, string password)
        {
            login = login.FormatToLoginParammeter();

            var employee = await _employeeRepository.Get(login);

            if (employee == null)
                return false;

            return employee.Password == password;
        }

        public async Task<IList<EmployeePermission>> GetEmployeePermissions(long employeeId)
        {
            return await _employeeRepository.GetEmployeePermissions(employeeId);
        }

        public async Task AddEmployeePermission(long employeeId, Permission permission)
        {
            var employee = await _employeeRepository.Get(employeeId);

            if (employee == null)
                throw new DomainException("Colaborador não encontrado.");

            var employeePermission = new EmployeePermission(employeeId, permission.Id);
            employee.AddPermission(employeePermission);

            await _employeeRepository.Update(employee);
            await _employeeRepository.UnitOfWork.Commit();
        }

        public async Task RemoveEmployeePermission(long employeeId, Permission permission)
        {
            var employee = await _employeeRepository.Get(employeeId);

            if (employee == null)
                throw new DomainException("Colaborador não encontrado.");

            var employeePermission = new EmployeePermission(employeeId, permission.Id);
            employee.RemovePermission(employeePermission);

            await _employeeRepository.Update(employee);
            await _employeeRepository.UnitOfWork.Commit();
        }

        public async Task<IList<Employee>> SearchEmployee(SearchEmployeeFilter searchFilter)
        {
            return await _employeeRepository.Search(searchFilter);
        }

        #endregion

        #region Customer

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            await _customerRepository.Add(customer);
            await _customerRepository.UnitOfWork.Commit();

            return customer;
        }
        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            await _customerRepository.Update(customer);
            await _customerRepository.UnitOfWork.Commit();

            return customer;
        }

        public async Task<IList<Customer>> SearchCustomer(SearchCustomerFilter searchFilter)
        {
            return await _customerRepository.Search(searchFilter);
        }

        public async Task<bool> AuthenticateCustomer(string login, string password)
        {
            login = login.FormatToLoginParammeter();

            var employee = await _customerRepository.Get(login);

            if (employee == null)
                return false;

            return employee.Password == password;
        }

        #endregion

        #region Permission

        public async Task<IList<Permission>> GetAllPermissions()
        {
            return await _permissionRepository.Get();
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            _customerRepository?.Dispose();
            _permissionRepository?.Dispose();
            _employeeRepository?.Dispose();
        }

        #endregion
    }
}

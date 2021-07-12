using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using CHStore.Application.Account.Domain.Entities;
using CHStore.Application.Account.ApplicationServices.DTO;
using CHStore.Application.Account.ApplicationServices.Interfaces;
using CHStore.Application.Account.DomainServices.Interfaces;

namespace CHStore.Application.Account.ApplicationServices.Services
{
    public class AccountApplicationService : IAccountApplicationService
    {
        private readonly IMapper _mapper;
        private readonly IAccountDomainService _accountDomainService;

        public AccountApplicationService(IMapper mapper, IAccountDomainService accountDomainService)
        {
            _mapper = mapper;
            _accountDomainService = accountDomainService;
        }

        #region Customer

        public async Task<CustomerDTO> CreateCustomer(CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);

            var customerInserted = await _accountDomainService.CreateCustomer(customer);

            return _mapper.Map<CustomerDTO>(customerInserted);
        }

        public async Task<CustomerDTO> UpdateCustomer(CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);

            var customerUpdated = await _accountDomainService.UpdateCustomer(customer);

            return _mapper.Map<CustomerDTO>(customerUpdated);
        }

        public async Task<bool> AuthenticateCustomer(string login, string password)
        {
            return await _accountDomainService.AuthenticateCustomer(login, password);
        }

        #endregion

        #region Employee

        public async Task<EmployeeDTO> CreateEmployee(EmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);

            var employeeInserted = await _accountDomainService.CreateEmployee(employee);

            return _mapper.Map<EmployeeDTO>(employeeInserted);
        }

        public async Task<EmployeeDTO> UpdateEmployee(EmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);

            var employeeUpdated = await _accountDomainService.UpdateEmployee(employee);

            return _mapper.Map<EmployeeDTO>(employeeUpdated);
        }

        public async Task<bool> AuthenticateEmployee(string login, string password)
        {
            return await _accountDomainService.AuthenticateEmployee(login, password);
        }

        public async Task<IList<EmployeePermissionDTO>> GetEmployeePermissions(long employeeId)
        {
            var employeePermissions = await _accountDomainService.GetEmployeePermissions(employeeId);

            return _mapper.Map<IList<EmployeePermissionDTO>>(employeePermissions);
        }

        public async Task AddEmployeePermission(long employeeId, PermissionDTO permissionDTO)
        {
            var permission = _mapper.Map<Permission>(permissionDTO);
            await _accountDomainService.AddEmployeePermission(employeeId, permission);
        }

        public async Task RemoveEmployeePermission(long employeeId, PermissionDTO permissionDTO)
        {
            var permission = _mapper.Map<Permission>(permissionDTO);
            await _accountDomainService.RemoveEmployeePermission(employeeId, permission);
        }

        #endregion

        #region Permission

        public async Task<IList<PermissionDTO>> GetAllPermissions()
        {
            var allPermissions = await _accountDomainService.GetAllPermissions();

            return _mapper.Map<IList<PermissionDTO>>(allPermissions);
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            _accountDomainService?.Dispose();
        }

        #endregion
    }
}

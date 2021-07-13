using System;
using System.Collections.Generic;
using CHStore.Application.Core.ValueObjects;

namespace CHStore.Application.Account.ApplicationServices.DTO
{
    public class EmployeeDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public Address Address { get; set; }
        public string Username { get; set; }
        public string CPF { get; set; }

        public IList<EmployeePermissionDTO> Permissions { get; set; }
    }
}

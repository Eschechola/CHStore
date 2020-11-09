using System.Collections.Generic;

namespace CHStore.Application.Account.ApplicationServices.DTO
{
    public class PermissionDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public IList<EmployeePermissionDTO> EmployeePermissions { get; set; }
    }
}

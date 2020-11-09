using CHStore.Application.Core.Data;
using System.Collections.Generic;

namespace CHStore.Application.Account.Domain.Entities
{
    public class Permission : Entity
    {
        public string Name { get; private set; }

        public IList<EmployeePermission> EmployeePermissions { get; set; }

        protected Permission(){}

        public Permission(string name)
        {
            Name = name;
        }
    }
}

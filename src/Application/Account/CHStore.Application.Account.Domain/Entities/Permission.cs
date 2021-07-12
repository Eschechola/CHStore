using CHStore.Application.Core.Data;
using CHStore.Application.Core.Data.Interfaces;
using System.Collections.Generic;

namespace CHStore.Application.Account.Domain.Entities
{
    public class Permission : Entity, IAggregateRoot
    {
        public string Name { get; private set; }

        public IList<EmployeePermission> EmployeePermissions { get; set; }

        protected Permission(){}

        public Permission(string name)
        {
            Name = name;
        }

        public bool Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}

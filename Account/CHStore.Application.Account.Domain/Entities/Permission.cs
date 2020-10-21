using CHStore.Application.Core.Data;

namespace CHStore.Application.Account.Domain.Entities
{
    public class Permission : Entity
    {
        public string Name { get; private set; }

        public Permission(string name)
        {
            Name = name;
        }
    }
}

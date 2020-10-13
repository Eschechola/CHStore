using System.Collections.Generic;
using CHStore.Application.Core.Data;

namespace CHStore.Application.Sales.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; private set; }

        public IList<Order> Orders { get; private set; }
    }
}

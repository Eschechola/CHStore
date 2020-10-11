using CHStore.Application.Core.Data;

namespace CHStore.Application.Sales.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public int Mount { get; private set; }
        public decimal Price { get; private set; }
    }
}

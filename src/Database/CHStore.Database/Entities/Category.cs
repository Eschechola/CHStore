using System.Collections.Generic;

namespace CHStore.Database.Entities
{
    public class Category : Entity
    {
        public string Name { get; private set; }

        public IList<Product> Products { get; private set; }

        public Category(string name)
        {
            Name = name;
        }
    }
}

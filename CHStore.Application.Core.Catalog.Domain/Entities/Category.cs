using CHStore.Application.Core.Data;
using CHStore.Application.Core.Exceptions;
using System.Collections.Generic;

namespace CHStore.Application.Core.Catalog.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; private set; }

        public IList<Product> Products { get; private set; }

        public Category(long id, string name) : base(id)
        {
            Name = name;
        }

        public void ChangeName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new DomainException("O Nome da categoria não pode ser vazio");

            Name = name;
        }
    }
}

using System.Collections.Generic;

namespace CHStore.Database.Entities
{
    public class Brand : Entity
    {
        public string Name { get; private set; }
        public string BrandLogoUrl { get; private set; }

        public IList<Product> Products { get; private set; }

        protected Brand()
        {
        }

        public Brand(
            string name,
            string brandLogoUrl)
        {
            Name = name;
            BrandLogoUrl = brandLogoUrl;
        }
    }
}

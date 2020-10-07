using Microsoft.EntityFrameworkCore;
using CHStore.Application.Core.Catalog.Domain.Entities;
using CHStore.Application.Core.Catalog.Infra.Data.Mapping;

namespace CHStore.Application.Core.Catalog.Infra.Data.Context
{
    public class CatalogContext : DbContext
    {
        public CatalogContext()
        {}

        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        { }
        
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-652APCE\SQLEXPRESS;Initial Catalog=CHSTORE;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new BrandMap());
        }
    }
}

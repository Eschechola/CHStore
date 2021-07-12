using CHStore.Application.Core.Catalog.Domain.Entities;
using CHStore.Application.Core.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CHStore.Application.Core.Catalog.Infra.Data.Context
{
    public class CatalogContext : BaseContext<CatalogContext>
    {
        #region Constructors

        public CatalogContext()
        {
        }

        public CatalogContext(DbContextOptions<CatalogContext> options)
            : base(options)
        {
        }

        #endregion

        #region DBSets

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}

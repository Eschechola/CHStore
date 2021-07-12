using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CHStore.Application.Catalog.ApplicationServices;
using CHStore.Application.Core.Catalog.DomainServices;
using CHStore.Application.Core.Catalog.Infra.Data.Context;
using CHStore.Application.Core.Catalog.Infra.Data.Interfaces;
using CHStore.Application.Core.Catalog.Infra.Data.Repositories;
using CHStore.Application.Catalog.ApplicationServices.Interfaces;
using CHStore.Application.Core.Catalog.DomainServices.Interfaces;

namespace CHStore.Web.Setup
{
    public static class DependenciesSetup
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            #region AutoMapper

            var autoMapperConfig = new MapperConfiguration(config =>
            {
                // Catalog
                config.CreateMap<Application.Core.Catalog.Domain.Entities.Brand, Application.Catalog.ApplicationServices.DTO.BrandDTO>().ReverseMap();
                config.CreateMap<Application.Core.Catalog.Domain.Entities.Category, Application.Catalog.ApplicationServices.DTO.CategoryDTO>().ReverseMap();
                config.CreateMap<Application.Core.Catalog.Domain.Entities.Product, Application.Catalog.ApplicationServices.DTO.ProductDTO>().ReverseMap();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());

            #endregion


            #region Catalog

            services.AddScoped<ICatalogApplicationService, CatalogApplicationService>();
            
            services.AddScoped<ICatalogDomainService, CatalogDomainService>();

            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddDbContext<CatalogContext>(options => options.UseSqlServer(configuration["ConnectionStrings:CHStore"]));

            #endregion


            return services;
        }
    }
}

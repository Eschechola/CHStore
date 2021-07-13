using CHStore.Application.Catalog.ApplicationServices.Interfaces;
using CHStore.Application.Core.Catalog.DomainServices.Interfaces;

namespace CHStore.Application.Catalog.ApplicationServices
{
    public class CatalogApplicationService : ICatalogApplicationService
    {
        private readonly ICatalogDomainService _catalogDomainService;

        public CatalogApplicationService(ICatalogDomainService catalogDomainService)
        {
            _catalogDomainService = catalogDomainService;
        }
    }
}

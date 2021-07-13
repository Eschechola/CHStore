using CHStore.Application.Sales.ApplicationServices.Interfaces;
using CHStore.Application.Sales.DomainServices.Interfaces;

namespace CHStore.Application.Sales.ApplicationServices.Services
{
    public class SalesApplicationService : ISalesApplicationService
    {
        private readonly ISalesDomainService _salesDomainService;

        public SalesApplicationService(ISalesDomainService salesDomainService)
        {
            _salesDomainService = salesDomainService;
        }
    }
}

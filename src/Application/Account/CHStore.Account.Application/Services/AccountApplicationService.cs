using CHStore.Application.Account.ApplicationServices.Interfaces;
using CHStore.Application.Account.DomainServices.Interfaces;

namespace CHStore.Application.Account.ApplicationServices.Services
{
    public class AccountApplicationService : IAccountApplicationService
    {
        private readonly IAccountDomainService _accountDomainService;

        public AccountApplicationService(IAccountDomainService accountDomainService)
        {
            _accountDomainService = accountDomainService;
        }
    }
}

using CHStore.Application.Catalog.ApplicationServices.Interfaces;
using CHStore.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CHStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICatalogApplicationService _catalogApplicationService;

        public HomeController(ICatalogApplicationService catalogApplicationService)
        {
            _catalogApplicationService = catalogApplicationService;
        }

        public async Task<IActionResult> Index()
        {
            var productsSearch = await _catalogApplicationService.GetLastProducts(mountOfProducts: 16);

            var viewModel = new HomeViewModel
            {
                LastProducts = productsSearch
            };

            return View(productsSearch);
        }
    }
}

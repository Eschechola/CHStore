using System;
using CHStore.Web.ViewModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CHStore.Application.Catalog.ApplicationServices.Interfaces;

namespace CHStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICatalogApplicationService _catalogApplicationService;

        public HomeController(ICatalogApplicationService catalogApplicationService)
        {
            _catalogApplicationService = catalogApplicationService;
        }

        [Route("/")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var viewModel = new HomeViewModel
                {
                    LastProducts = await _catalogApplicationService.GetLastProducts(mountOfProducts: 16, onlyActives: true),
                    MostSellingProducts = await _catalogApplicationService.GetLastProducts(mountOfProducts: 4, onlyActives: true)
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("/shop")]
        public async Task<IActionResult> Shop()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

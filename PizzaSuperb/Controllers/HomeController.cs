using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PizzaSuperb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBusinessServicesManager _bll;

        public HomeController(IBusinessServicesManager bll)
        {
            _bll = bll;
        }

        public async Task<IActionResult> Index()
        {
            var productList = await _bll.ShowcaseService.GetSaleProducts();

            return View(productList);
        }
    }
}
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PizzaSuperb.Controllers
{
    public class ShowcaseController : Controller
    {
        private readonly IBusinessServicesManager _bll;

        public ShowcaseController(IBusinessServicesManager bll)
        {
            _bll = bll;
        }

        public async Task<IActionResult> Index()
        {
            var productList = await _bll.ShowcaseService.GetSaleProducts();
            return View(productList);
        }

        [HttpGet]
        public async Task<IActionResult> ProductsByName(string name)
        {
            var productList = await _bll.ShowcaseService.GetSaleProducts(name);
            return PartialView("_ProductsByName", productList);
        }
    }
}
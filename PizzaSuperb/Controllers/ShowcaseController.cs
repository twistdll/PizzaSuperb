using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PizzaSuperb.Constants;
using PizzaSuperb.Extensions;

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
            var nameCountPairs = Request.Cookies.ToFilteredPairs(CookieConstants.ProductPrefix).ToList();
            var model = productList.ToViewModelList(nameCountPairs);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ProductsByName(string name)
        {
            var productList = await _bll.ShowcaseService.GetSaleProducts(name);
            var nameCountPairs = Request.Cookies.ToFilteredPairs(CookieConstants.ProductPrefix).ToList();
            var model = productList.ToViewModelList(nameCountPairs);

            return PartialView("_ProductsByName", model);
        }
    }
}
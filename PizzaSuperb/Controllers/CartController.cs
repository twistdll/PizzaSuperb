using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PizzaSuperb.ViewModels;

namespace PizzaSuperb.Controllers
{
    public class CartController : Controller
    {
        private readonly IBusinessServicesManager _bll;

        public CartController(IBusinessServicesManager bll)
        {
            _bll = bll;
        }

        //TODO: get products from cookies 
        public async Task<IActionResult> Index(OrderViewModel model)
        {
            var doppings = await _bll.CartService.GetDoppings();

            model.Doppings = doppings;

            return View(model);
        }

        // autorized only in future
        [HttpPost]
        public async void CreateOrder()
        { 
            
        }
    }
}

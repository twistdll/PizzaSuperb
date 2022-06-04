using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PizzaSuperb.Constants;
using PizzaSuperb.Extensions;
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

        public async Task<IActionResult> Index(OrderViewModel model)
        {
            var namesCountPairs = Request.Cookies.ToFilteredPairs(CookieConstants.ProductPrefix);
            var pizzaTypes = new List<PizzaTypeOrderViewModel>();

            foreach (var item in namesCountPairs)
            {
                string name = item.Key.Split(CookieConstants.ProductPrefix)[1].Replace("%20"," ");
                string? photoUrl = await _bll.CartService.GetPhotoByName(name);
                double price = (await _bll.CartService.GetPriceByName(name)) ?? 0;

                if (price > 0)
                {
                    pizzaTypes.Add(new PizzaTypeOrderViewModel()
                    {
                        PhotoUrl = photoUrl,
                        Name = name,
                        Price = price,
                        Count = int.Parse(item.Value)
                    });
                }
            }           

            var doppings = await _bll.CartService.GetDoppings();

            model.Doppings = doppings;
            model.PizzaTypes = pizzaTypes;
            return View(model);
        }

        // autorized only in future
        [HttpPost]
        public async void CreateOrder()
        { 
            
        }
    }
}

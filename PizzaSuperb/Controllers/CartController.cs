using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PizzaSuperb.ViewModels;

namespace PizzaSuperb.Controllers
{
    public class CartController : Controller
    {
        private readonly IBusinessServicesManager _bll;
        private readonly string _cookieNameIdentifier = "product";

        public CartController(IBusinessServicesManager bll)
        {
            _bll = bll;
        }

        //TODO: get products from cookies 
        public async Task<IActionResult> Index(OrderViewModel model)
        {
            var namesCountPairs= Request.Cookies.Where(x => 
                                                       x.Key.StartsWith(_cookieNameIdentifier) 
                                                       && int.Parse(x.Value) > 0);
            var pizzaTypes = new List<PizzaTypeOrderViewModel>();

            foreach (var item in namesCountPairs)
            {
                string name = item.Key.Split(_cookieNameIdentifier)[1];
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

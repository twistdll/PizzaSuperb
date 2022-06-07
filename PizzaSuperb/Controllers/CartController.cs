using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PizzaSuperb.Constants;
using PizzaSuperb.Extensions;
using PizzaSuperb.Models;
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

        public async Task<IActionResult> Index()
        {
            var namesCountPairs = Request.Cookies.ToFilteredPairs(CookieConstants.ProductPrefix);
            var pizzaTypes = new List<PizzaTypeOrderViewModel>();

            foreach (var item in namesCountPairs)
            {
                string name = item.Key.ToItemName(CookieConstants.ProductPrefix);
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
            namesCountPairs = Request.Cookies.ToFilteredPairs(CookieConstants.DoppingPrefix);
            var doppingViewModels = new List<DoppingOrderViewModel>();

            foreach (var item in doppings)
            {
                var targetCookieValue = namesCountPairs.Where(x => x.Key.ToItemName(CookieConstants.DoppingPrefix) == item.Name)
                                                       .FirstOrDefault()
                                                       .Value;

                doppingViewModels.Add(new DoppingOrderViewModel()
                {
                    PhotoUrl = item.PhotoUrl,
                    Name = item.Name,
                    Price = item.Price,
                    Count = string.IsNullOrEmpty(targetCookieValue) ? 0 : int.Parse(targetCookieValue)
                });
            }

            var model = new OrderViewModel();
            model.Doppings = doppingViewModels;
            model.PizzaTypes = pizzaTypes;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] UserOrderInfo info)
        {
            var user = await _bll.UserService.GetUser(info.Email, info.Password);

            if (user == null)
                return BadRequest();


            var pairs = Request.Cookies
                               .ToFilteredPairs(CookieConstants.ProductPrefix, CookieConstants.DoppingPrefix)
                               .ToDictionary(x => x.Key, x => x.Value);
            var parsedPairs = new Dictionary<string, string>();
            foreach (var item in pairs)
            {
                if (int.Parse(item.Value) > 0)
                    parsedPairs.Add(item.Key.Split(new string[] { CookieConstants.ProductPrefix, CookieConstants.DoppingPrefix }, StringSplitOptions.None)[1]
                                        .Replace("%20", " "),
                                item.Value);
            }

            bool created = await _bll.CartService.CreateOrder(user, parsedPairs, info.Address);

            if (created)
                return Ok();
            else
                return BadRequest();
        }
    }
}

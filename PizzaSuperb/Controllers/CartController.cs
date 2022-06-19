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
     
            // var doppings = await _bll.CartService.GetDoppings();
            // namesCountPairs = Request.Cookies.ToFilteredPairs(CookieConstants.DoppingPrefix);
            // var doppingViewModels = new List<DoppingOrderViewModel>();
            //
            // foreach (var item in doppings)
            // {
            //     var targetCookieValue = namesCountPairs.FirstOrDefault(x => x.Key.ToItemName(CookieConstants.DoppingPrefix) == item.Name).Value;
            //
            //     doppingViewModels.Add(new DoppingOrderViewModel()
            //     {
            //         PhotoUrl = item.PhotoUrl,
            //         Name = item.Name,
            //         Price = item.Price,
            //         Count = string.IsNullOrEmpty(targetCookieValue) ? 0 : int.Parse(targetCookieValue)
            //     });
            // }

            //var deliveryCookieValue = Request.Cookies.ToFilteredPairs(CookieConstants.ActiveDeliveryPrefix).FirstOrDefault().Value;
            //var hasActiveDeliveries = deliveryCookieValue == null ? false : bool.Parse(deliveryCookieValue);

            var model = new OrderViewModel()
            {
                //Doppings = doppingViewModels,
                PizzaTypes = pizzaTypes
                //HasActiveDeliveries = hasActiveDeliveries
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] UserOrderInfo info)
        {
            var user = await _bll.UserService.GetUser(info.Email, info.Password);
            var activeDeliveries = await _bll.CartService.GetActiveDeliveryStatus(user);

            if (user == null || activeDeliveries)
            {
                SetCookieResponse("HasActiveDelivery", "false", 30);
                return BadRequest();
            }

            var pairs = Request.Cookies
                               .ToFilteredPairs(CookieConstants.ProductPrefix, CookieConstants.DoppingPrefix)
                               .ToDictionary(x => x.Key, x => x.Value);
            var parsedPairs = new Dictionary<string, string>();

            foreach (var item in pairs)
            {
                if (int.Parse(item.Value) > 0)
                    parsedPairs.Add(item.Key.ToItemName(CookieConstants.ProductPrefix, CookieConstants.DoppingPrefix),
                                    item.Value);
            }

            bool created = await _bll.CartService.CreateOrder(user, parsedPairs, info.Address);

            if (created)
            {
                SetCookieResponse("HasActiveDelivery", "true", 30);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        
        #region Private methods
        private void SetCookieResponse(string cookieName, string cookieValue, int expiredDaysTime)
        {
            Response.Cookies.Append(cookieName, cookieValue, new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(expiredDaysTime)
            });
        }
        #endregion
    }
}

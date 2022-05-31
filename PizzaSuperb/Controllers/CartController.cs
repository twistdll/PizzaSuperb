using Microsoft.AspNetCore.Mvc;

namespace PizzaSuperb.Controllers
{
    public class CartController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}

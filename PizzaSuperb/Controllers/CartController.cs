using Microsoft.AspNetCore.Mvc;

namespace PizzaSuperb.Controllers
{
    public class CartController : Controller
    {

        [Route("Cart/{uuid}")]
        public ActionResult Index(Guid uuid)
        {
            return View();
        }
    }
}

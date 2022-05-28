using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PizzaSuperb.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
﻿using Microsoft.AspNetCore.Mvc;

namespace PizzaSuperb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
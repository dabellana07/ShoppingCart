﻿using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
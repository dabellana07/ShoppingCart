using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShoppingCart.Data;
using ShoppingCart.Models;

namespace ShoppingCart.Products.Controllers
{
    [Area("Products")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShoppingCartContext _context;

        public HomeController(
            ILogger<HomeController> logger,
            ShoppingCartContext context
        )
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var shopItems = await _context.Items.ToListAsync();
            return View(shopItems);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

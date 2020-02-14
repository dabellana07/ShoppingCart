using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShoppingCart.Data;
using ShoppingCart.Extensions;
using ShoppingCart.Models;

namespace ShoppingCart.Products.Controllers
{
    [Area("Products")]
    public class CartController : Controller
    {
        private readonly string CartSessionKey = "_Cart";
        private readonly ILogger<CartController> _logger;
        private readonly ShoppingCartContext _context;

        public CartController(
            ILogger<CartController> logger,
            ShoppingCartContext context
        )
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var cartItems = HttpContext.Session.Get<List<Item>>(CartSessionKey);
            if (cartItems == null)
            {
                cartItems = new List<Item>();
            }
            return View(cartItems);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(int id)
        {
            var cartItems = HttpContext.Session.Get<List<Item>>(CartSessionKey);
            
            if (cartItems == null) {
                cartItems = new List<Item>();
            }

            var item = await _context.Items.FirstOrDefaultAsync(i => i.ID == id);

            if (item != null)
            {
                cartItems.Add(item);
                HttpContext.Session.Set<List<Item>>(CartSessionKey, cartItems);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var cartItems = HttpContext.Session.Get<List<Item>>(CartSessionKey);

            var itemToRemove = cartItems.FirstOrDefault(i => i.ID == id);

            if (itemToRemove != null)
            {
                cartItems.Remove(itemToRemove);
                HttpContext.Session.Set(CartSessionKey, cartItems);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShoppingCart.Data;
using ShoppingCart.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Services.Controllers
{
    [Area("Services")]
    public class HomeController : Controller
    {
        private readonly ShoppingCartContext _context;
        private readonly ILogger<HomeController> _logger;

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
            var shopItems = await _context.Items
                .Where(i => i.Type == ItemType.Service)
                .ToListAsync();
            return View(shopItems);
        }
    }
}
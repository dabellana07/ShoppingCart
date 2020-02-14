using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShoppingCart.Data;
using ShoppingCart.Models;
using System.Diagnostics;
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Price")]Item item)
        {
            try
            {
                item.Type = ItemType.Service;

                if (ModelState.IsValid)
                {
                    _context.Add(item);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. ");
            }
            return View(item);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var item = await _context.Items
                .FirstOrDefaultAsync(i => i.ID == id);

            if (item == null)
                return NotFound();

            return View(item);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
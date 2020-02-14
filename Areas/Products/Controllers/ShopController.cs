using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data;
using ShoppingCart.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCart.Products.Controllers
{
    [Area("Products")]
    public class ShopController : Controller
    {
        private readonly ShoppingCartContext _context;

        public ShopController(ShoppingCartContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var shopItems = await _context.Items.ToListAsync();
            return View(shopItems);
        }

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
    }
}
using System.Linq;
using ShoppingCart.Models;

namespace ShoppingCart.Data
{
    public static class DbInitializer {
        public static void Initialize(ShoppingCartContext context)
        {
            if (context.Items.Any())
                return;
            
            var items = new Item[]
            {
                new Item { Name = "Laptop", Price = 1000.00 },
                new Item { Name = "Phone", Price = 800.00 },
                new Item { Name = "Tablet", Price = 600.00 },
                new Item { Name = "Watch", Price = 100.00 },
                new Item { Name = "Earphones", Price = 80.00 },
                new Item { Name = "Headphones", Price = 100.00 }
            };

            foreach (var item in items)
            {
                context.Items.Add(item);
            }

            context.SaveChanges();
        }
    }
}
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
                new Item { Name = "Laptop", Price = 1000.00, Type = ItemType.Product },
                new Item { Name = "Phone", Price = 800.00, Type = ItemType.Product },
                new Item { Name = "Tablet", Price = 600.00, Type = ItemType.Product },
                new Item { Name = "Watch", Price = 100.00, Type = ItemType.Product },
                new Item { Name = "Earphones", Price = 80.00, Type = ItemType.Product },
                new Item { Name = "Headphones", Price = 100.00, Type = ItemType.Product },

                new Item { Name = "Laptop Repair", Price = 500.00, Type = ItemType.Service },
                new Item { Name = "Phone Repair", Price = 300.00, Type = ItemType.Service },
                new Item { Name = "Wallpaper Artwork", Price = 100.00, Type = ItemType.Service },
                new Item { Name = "Make Soundtracks", Price = 100.00, Type = ItemType.Service },
            };

            foreach (var item in items)
            {
                context.Items.Add(item);
            }

            context.SaveChanges();
        }
    }
}
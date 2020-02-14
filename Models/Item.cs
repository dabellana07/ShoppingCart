using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class Item
    {
        public int ID { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }

        public ItemType Type { get; set; }
    }
}
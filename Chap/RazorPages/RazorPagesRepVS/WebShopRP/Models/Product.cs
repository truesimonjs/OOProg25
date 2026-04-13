using System.ComponentModel.DataAnnotations;

namespace WebShopRP.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Must give a name")]
        public string Name { get; set; }
        [Range (0, double.MaxValue,ErrorMessage = "Must be a positive number")]
        public double Price { get; set; }
        public Product() { }
        public Product ( string name, double price)
        {
            Id = 0;
            Name = name;
            Price = price;
        }

    }
}

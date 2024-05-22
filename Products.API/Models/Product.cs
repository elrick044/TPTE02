using System.ComponentModel.DataAnnotations;

namespace Products.API.Models
{
    public class Product
    {
        [Key]
        public long ProductID { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
    }

}
//joão
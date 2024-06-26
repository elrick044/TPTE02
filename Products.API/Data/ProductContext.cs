using Microsoft.EntityFrameworkCore;
using Products.API.Models;

namespace Products.API.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options){

        }

        public DbSet<Product> ProductItems { get; set; }
    }
}

//commit
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Products.API.Data;
using Products.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Products.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly ProductContext _context;

        public ProductController(ProductContext context)
        {
            _context = context;
        }

        [HttpGet]
        public  ActionResult<List<Product>> Product() {
            // return Created();
            return _context.ProductItems.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product?>> ProductByID(long id) {
            return await _context.ProductItems.Where(i => i.ProductID.Equals(id)).FirstAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Product(Product product) {
            _context.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Product", product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Product(long id, Product product) {
            if (id != product.ProductID) {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();

            // return Created();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> ProductDelete(long id) {
            var product =await ProductByID(id);
            _context.Remove<Product>(product.Value!);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }

}
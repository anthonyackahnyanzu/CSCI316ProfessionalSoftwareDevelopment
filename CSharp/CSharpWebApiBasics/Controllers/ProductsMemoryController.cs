using Microsoft.AspNetCore.Mvc;
using CSharpWebApiBasics.Models;

namespace CSharpWebApiBasics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsMemoryController : ControllerBase
    {
        // In-memory list of products
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Apple", Price = 0.99M },
            new Product { Id = 2, Name = "Banana", Price = 0.59M }
        };

        // GET: api/ProductsMemory
        // Retrieves all products from memory
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get() => _products;

        // POST: api/ProductsMemory
        // Adds a new product to the in-memory list
        [HttpPost]
        public ActionResult<Product> Post(Product product)
        {
            // Assign a new ID to the product
            product.Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1;
            _products.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        // PUT: api/ProductsMemory/{id}
        // Updates an existing product in memory
        [HttpPut("{id}")]
        public IActionResult Put(int id, Product product)
        {
            // Find the product with the specified ID
            var existing = _products.FirstOrDefault(p => p.Id == id);
            if (existing == null) return NotFound();
            // Update the product details
            existing.Name = product.Name;
            existing.Price = product.Price;
            return NoContent();
        }

        // DELETE: api/ProductsMemory/{id}
        // Deletes a product from memory
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Find the product with the specified ID
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            // Remove the product from the list
            _products.Remove(product);
            return NoContent();
        }
    }
}
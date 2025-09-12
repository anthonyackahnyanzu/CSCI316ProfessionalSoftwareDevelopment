using Microsoft.AspNetCore.Mvc;
using CSharpWebApiBasics.Models;
using CSharpWebApiBasics.Helpers;

namespace CSharpWebApiBasics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsFileController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        // Inject IConfiguration to access app settings and environment variables
        public ProductsFileController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/ProductsFile
        // Retrieves all products from the file
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                var filePath = ProductFileHelper.GetFilePath(_configuration);
                return ProductFileHelper.ReadProducts(filePath);
            }
            catch (Exception ex)
            {
                // Log the error if logging is set up
                return StatusCode(500, $"Error reading products: {ex.Message}");
            }
        }

        // POST: api/ProductsFile
        // Adds a new product to the file
        [HttpPost]
        public ActionResult<Product> Post(Product product)
        {
            try
            {
                var filePath = ProductFileHelper.GetFilePath(_configuration);
                var products = ProductFileHelper.ReadProducts(filePath);
                // Assign a new ID to the product
                product.Id = products.Count > 0 ? products.Max(p => p.Id) + 1 : 1;
                products.Add(product);
                // Save the updated product list to the file
                ProductFileHelper.WriteProducts(products, filePath);
                return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error adding product: {ex.Message}");
            }
        }

        // PUT: api/ProductsFile/{id}
        // Updates an existing product in the file
        [HttpPut("{id}")]
        public IActionResult Put(int id, Product product)
        {
            try
            {
                var filePath = ProductFileHelper.GetFilePath(_configuration);
                var products = ProductFileHelper.ReadProducts(filePath);
                // Find the product with the specified ID
                var existing = products.FirstOrDefault(p => p.Id == id);
                if (existing == null) return NotFound();
                // Update the product details
                existing.Name = product.Name;
                existing.Price = product.Price;
                // Save the updated product list to the file
                ProductFileHelper.WriteProducts(products, filePath);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating product: {ex.Message}");
            }
        }

        // DELETE: api/ProductsFile/{id}
        // Deletes a product from the file
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var filePath = ProductFileHelper.GetFilePath(_configuration);
                var products = ProductFileHelper.ReadProducts(filePath);
                // Find the product with the specified ID
                var product = products.FirstOrDefault(p => p.Id == id);
                if (product == null) return NotFound();
                // Remove the product from the list
                products.Remove(product);
                // Save the updated product list to the file
                ProductFileHelper.WriteProducts(products, filePath);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting product: {ex.Message}");
            }
        }

        // POST: api/ProductsFile/echo
        // Demonstrates reading a Product object from the request body
        [HttpPost("echo")]
        public ActionResult<Product> EchoProduct([FromBody] Product product)
        {
            // Returns the product received in the request body
            return Ok(product);
        }
    }
}
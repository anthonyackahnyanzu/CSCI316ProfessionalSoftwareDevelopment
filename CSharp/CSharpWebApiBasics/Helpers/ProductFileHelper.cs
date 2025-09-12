using System.Text.Json;
using CSharpWebApiBasics.Models;
using Microsoft.Extensions.Configuration;

namespace CSharpWebApiBasics.Helpers
{
    // Helper class for reading and writing Product data to a file
    public static class ProductFileHelper
    {
        // Gets the file path from environment variable or configuration
        public static string GetFilePath(IConfiguration configuration)
        {
            // Check for environment variable first
            var envPath = Environment.GetEnvironmentVariable("PRODUCTS_FILE_PATH");
            if (!string.IsNullOrEmpty(envPath)) return envPath;
            // Fallback to configuration value
            return configuration["ProductsFilePath"] ?? "products.json";
        }

        // Reads the list of products from the file
        public static List<Product> ReadProducts(string filePath)
        {
            // If the file does not exist, return an empty list
            if (!File.Exists(filePath)) return new List<Product>();
            // Read the JSON content from the file
            var json = File.ReadAllText(filePath);
            // Deserialize the JSON into a list of Product objects
            return JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
        }

        // Writes the list of products to the file
        public static void WriteProducts(List<Product> products, string filePath)
        {
            // Serialize the list of products to JSON
            var json = JsonSerializer.Serialize(products);
            // Write the JSON content to the file
            File.WriteAllText(filePath, json);
        }
    }
}
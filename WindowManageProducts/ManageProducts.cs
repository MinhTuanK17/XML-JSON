using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace ManageProductsApp
{
    public record Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
    }

    public class ManageProducts
    {
        string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProductList.json");
        List<Product> products = new List<Product>();

        public List<Product> GetProducts()
        {
            GetDataFromFile();
            return products;
        }

        public void StoreToFile()
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(fileName, jsonData);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error storing data to file: {ex.Message}");
            }
        }

        public void GetDataFromFile()
        {
            try
            {
                if (File.Exists(fileName))
                {
                    string jsonData = File.ReadAllText(fileName);
                    products = JsonSerializer.Deserialize<List<Product>>(jsonData);
                }
                else
                {
                    throw new FileNotFoundException($"The file {fileName} does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting data from file: {ex.Message}");
            }
        }

        public void InsertProduct(Product Product)
        {
            try
            {
                Product p = products.SingleOrDefault(p => p.ProductID == Product.ProductID);
                if (p != null)
                {
                    throw new Exception("This product already exists.");
                }
                products.Add(Product);
                StoreToFile();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inserting product: {ex.Message}");
            }
        }

        public void UpdateProduct(Product Product)
        {
            try
            {
                Product p = products.SingleOrDefault(p => p.ProductID == Product.ProductID);
                if (p == null)
                {
                    throw new Exception("This product did not exist.");
                }
                else
                {
                    p.ProductName = Product.ProductName;
                    StoreToFile();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating product: {ex.Message}");
            }
        }

        public void DeleteProduct(Product Product)
        {
            try
            {
                Product p = products.SingleOrDefault(p => p.ProductID == Product.ProductID);
                if (p == null)
                {
                    throw new Exception("This product did not exist.");
                }
                else
                {
                    products.Remove(p);
                    StoreToFile();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting product: {ex.Message}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.App.SRP.Bad
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        private static List<Product> ProductList = new List<Product>();


        public List<Product> GetProducts() => ProductList;


        public Product()
        {
            ProductList = new()
            {
                new() { Id = 1, Name = "Kalem 1" },
                new() { Id = 2, Name = "Kalem 2" },
                new() { Id = 3, Name = "Kalem 3" },
                new() { Id = 4, Name = "Kalem 4" },
                new() { Id = 5, Name = "Kalem 5" },
            };
        }


        public void SaveOrUpdate(Product product)
        {
            var hasProduct = ProductList.Any(p => p.Id == product.Id);

            if (!hasProduct)
            {
                ProductList.Add(product);
            }
            else
            {
                var index = ProductList.FindIndex(p => p.Id == product.Id);
                ProductList[index] = product;
            }
        }


        public void Delete(int id)
        {
            var product = ProductList.FirstOrDefault(p => p.Id == id);


            if (product == null)
            {
                throw new Exception("Ürün bulunamadı");
            }

            ProductList.Remove(product);
        }



        public void WriteConsole()
        {
            ProductList.ForEach(p => Console.WriteLine($"Id: {p.Id} Name: {p.Name}"));
        }
    }
}

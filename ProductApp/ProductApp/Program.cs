using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            // TODO: Replace with your local URI.
            string serviceUri = "http://localhost:54155/";
            var container = new Default.Container(new Uri(serviceUri));

            var product = new ProductService.Models.Product()
            {
                Name = "figet spinner",
                Category = "Toys",
                Price = 5.00M
            };

            AddProduct(container, product);
            ListAllProducts(container);

            Console.ReadKey();
        }

        // Get an entire entity set.
        static void ListAllProducts(Default.Container container)
        {
            foreach (var p in container.Products)
            {
                Console.WriteLine("{0} {1} {2}", p.Name, p.Price, p.Category);
            }
        }

        static void AddProduct(Default.Container container, ProductService.Models.Product product)
        {
            container.AddToProducts(product);
            var serviceResponse = container.SaveChanges();
            foreach (var operationResponse in serviceResponse)
            {
                Console.WriteLine("Response: {0}", operationResponse.StatusCode);
            }
        }
    }
}

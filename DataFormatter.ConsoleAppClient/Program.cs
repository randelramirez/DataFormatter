using DataFormatter.Core;
using DataFormatter.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Xml.Serialization;
using DataFormatter.ConsoleAppClient.DTOs;

namespace DataFormatter.ConsoleAppClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataContext = new DataContext();
            dataContext.Configuration.LazyLoadingEnabled = false;
            dataContext.Configuration.ProxyCreationEnabled = false;
            var data = dataContext.Products.Include(p => p.Supplier).Select(p => new ProductDTO { Id = p.Id, Name = p.Name, Price = p.Price, Supplier = p.Supplier }).ToList();

            var jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            var x = data.ToList();
            var stringwriter = new System.IO.StringWriter();
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(List<ProductDTO>));
            xmlSerializer.Serialize(stringwriter, x);


            var xmlResult = stringwriter.ToString();

            Console.WriteLine(jsonResult);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(xmlResult);
            Console.ReadKey();
            
        }
    }

   
}

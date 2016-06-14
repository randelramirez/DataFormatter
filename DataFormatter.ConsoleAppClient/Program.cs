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
            //dataContext.Configuration.LazyLoadingEnabled = false;
            //dataContext.Configuration.ProxyCreationEnabled = false;


            var json1 = SerializeJSON1(dataContext);
            Console.WriteLine(json1);
          
            Console.ReadKey();

        }

        // EFContext lazy loading enabled
        // proxies enabled
        // using projection, anonymous object, no DTO.
        static string SerializeJSON1(DataContext context)
        {
            var data = context.Products.Include(p => p.Supplier);
            var toJson = data.Select(p => new { Id = p.Id, Price = p.Price, Supplier = p.Supplier }).ToList();
            var jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(toJson);
            return jsonResult;
        }

        // EFContext lazy loading enabled
        // EFContext proxy creation enabled
        // using DTO
        static string SerializeXML1(DataContext context)
        {
            var data = context.Products.Include(p => p.Supplier);
            var toXml = data.ToList().Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Supplier = new SupplierDTO
                {
                    Id = p.Supplier.Id,
                    Name = p.Name,
                    Address = p.Supplier.Address
                }
            }).ToList();
            var stringwriter = new System.IO.StringWriter();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ProductDTO>));
            xmlSerializer.Serialize(stringwriter, toXml);

            var xmlResult = stringwriter.ToString();
            return xmlResult;
        }
    }


}

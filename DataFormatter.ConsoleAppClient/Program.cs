using DataFormatter.ConsoleAppClient.ViewModels;
using DataFormatter.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Xml.Serialization;

namespace DataFormatter.ConsoleAppClient
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Lazy Loading Note

            /*
             Turn lazy loading off for serialization
             
             Lazy loading and serialization don’t mix well, and if you aren’t careful you can end up querying for your entire database 
             just because lazy loading is enabled.Most serializers work by accessing each property on an instance of a type.
             Property access triggers lazy loading, so more entities get serialized.
             On those entities properties are accessed, and even more entities are loaded.
             It’s a good practice to turn lazy loading off before you serialize an entity.The following sections show how to do this.
            */
            //https://msdn.microsoft.com/en-us/data/jj574232.aspx
            #endregion

            var dataContext = new DataContext();
            //dataContext.Configuration.LazyLoadingEnabled = false;
            //dataContext.Configuration.ProxyCreationEnabled = false;

            //not working
            var json1 = SerializeJSONAnonymousObject(dataContext);
            Console.WriteLine(json1);

            var json2 = SerializeJSONWithDTO(dataContext);
            Console.WriteLine(json2);

            Console.WriteLine();
            var xml1 = SerializeXML1(dataContext);
            Console.WriteLine(xml1);

            Console.ReadKey();

        }

        // EFContext lazy loading enabled
        // proxies enabled
        // using projection, anonymous object, no DTO.
        // so far works when lazy loading = false
        static string SerializeJSONAnonymousObject(DataContext context)
        {
            var data = context.Products.Include(p => p.Supplier);
            var toJson = data.Select(p => new { Id = p.Id, Price = p.Price, Supplier = p.Supplier }).ToList();
            var jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(toJson);
            return jsonResult;
        }

        static string SerializeJSONWithDTO(DataContext context)
        {
            var data = context.Products.Include(p => p.Supplier);
            var toJson = data.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Supplier = new SupplierViewModel
                {
                    Id = p.Supplier.Id,
                    Name = p.Supplier.Name,
                    Address = p.Supplier.Address
                }
            });
            var jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(toJson);
            return jsonResult;
        }

        // EFContext lazy loading enabled
        // EFContext proxy creation enabled
        // using DTO
        static string SerializeXML1(DataContext context)
        {
            var data = context.Products.Include(p => p.Supplier);
            var toXml = data.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Supplier = new SupplierViewModel
                {
                    Id = p.Supplier.Id,
                    Name = p.Name,
                    Address = p.Supplier.Address
                    
                }
            }).ToList();

            var stringwriter = new System.IO.StringWriter();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ProductViewModel>));
            xmlSerializer.Serialize(stringwriter, toXml);
            var xmlResult = stringwriter.ToString();
            return xmlResult;
        }
    }
}

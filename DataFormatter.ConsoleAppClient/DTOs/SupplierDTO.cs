using DataFormatter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataFormatter.ConsoleAppClient.DTOs
{
    public class SupplierDTO  : BusinessPartner
    {
        // see comments on Supplier class
        // we can add XmlIgnore attribute below or simply in the client code omit this property when mapping to this dto
        // ex. data.Select(p = new DTO{ Id = p.Id,  //Products = p.Products});

 
        public  List<Product> Products { get; set; }
    }
}

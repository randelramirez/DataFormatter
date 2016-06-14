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

        // might need to add script ignore, or xml ignore on properties that won't be serialized since 
        // it doesn't make sense to actually add {property: null} on the actual serialized string result.
        // but as stated above it might depend on the use case because what if we are serializing the SupplierDTO and we wanted to include its products
        // currently we are serializing Products entity on the client(console app)
        public List<Product> Products { get; set; }
    }
}

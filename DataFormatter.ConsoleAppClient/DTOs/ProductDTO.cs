using DataFormatter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataFormatter.ConsoleAppClient.DTOs
{
    [XmlType(TypeName = "Product")]
    [Serializable]
    public class ProductDTO
    {
        [XmlElement("ID")]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public SupplierDTO Supplier { get; set; }
    }
}

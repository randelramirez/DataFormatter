using DataFormatter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataFormatter.ConsoleAppClient.ViewModels
{
    [XmlType(TypeName = "Product")]
    [Serializable]
    public class ProductViewModel
    {
        [XmlElement("ID")]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public SupplierViewModel Supplier { get; set; }
    }
}

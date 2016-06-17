using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataFormatter.Core
{
    public class Supplier : BusinessPartner
    {
        //if the client is not going to use a DTO then the attribute below is required, because going to client code(Console Application) =>
        //we are serializing a Product type of object and Supplier contains a property List of Products. Similar to circular reference error during JSON serialization
        //note XmlSerializer does not support interfaces, so ICollection must be changed to List, otherwise use a DTO because XmlSerializer does not support anonymous objects

        public virtual ICollection<Product> Products { get; set; }

        //note for json serialization
        // if proxies are enabled then virtual properties with interfaces types will have proxies, and this could cause an error once the application serializes this model
 
    }
}

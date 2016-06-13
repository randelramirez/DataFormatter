using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFormatter.Core
{
    public class Supplier : BusinessPartner
    {
        public virtual ICollection<Product> Products { get; set; }
    }
}

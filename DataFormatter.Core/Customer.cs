using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFormatter.Core
{
    public class Customer : BusinessPartner
    {
        public ICollection<SalesOrderHeader> Orders { get; set; }

    }
}

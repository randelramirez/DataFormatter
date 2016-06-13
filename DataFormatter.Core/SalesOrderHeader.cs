using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFormatter.Core
{
    public class SalesOrderHeader
    {
        public int Id { get; set; }


        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<SalesOrderDetail> OrderDetails { get; set; }

    }
}

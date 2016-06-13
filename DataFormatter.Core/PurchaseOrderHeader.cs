using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFormatter.Core
{
    public class PurchaseOrderHeader
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }



    }
}

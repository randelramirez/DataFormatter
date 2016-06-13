using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFormatter.Core
{
    public class PurchaseOrderDetail
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public int PurchaseOrderHeaderId { get; set; }

        public virtual Product Product { get; set; }

        public virtual PurchaseOrderHeader PurchaseOrderHeader { get; set; }
    }
}

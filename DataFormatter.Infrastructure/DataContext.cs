using DataFormatter.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFormatter.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            Database.SetInitializer<DataContext>(new DataInitializer());
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<PurchaseOrderHeader> PurchaseOrderHeader { get; set; }

        public DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }

        public DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }

        public DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab3.Models
{
    public class DBContext : DbContext
    {
        public DBContext() : base("DbContext")
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public string PIB { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int ProductNumber { get; set; }
        public virtual Product Product { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string File { get; set; }
    }
}
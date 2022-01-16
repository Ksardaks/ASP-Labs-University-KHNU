using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4_5_6_7.Models
{
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
        public string ProductNameEN { get; set; }
        public double Price { get; set; }
        public double PriceEN { get; set; }
        public string File { get; set; }
        public virtual List<Category> Categories { get; set; }

        public Product()
        {
            Categories = new List<Category>();
        }
    }

    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryNameEN { get; set; }
        public virtual List<Product> Products { get; set; }

        public Category()
        {
            Products = new List<Product>();
        }
    }
}
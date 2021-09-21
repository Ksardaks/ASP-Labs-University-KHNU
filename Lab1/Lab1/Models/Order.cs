using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1.Models
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
}
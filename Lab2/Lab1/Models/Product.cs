using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1.Models
{
    public class Auto
    {
        public int Id { get; set; }
        public string AutoModel { get; set; }
        public string Manufacturer { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public string File { get; set; }
    }
}
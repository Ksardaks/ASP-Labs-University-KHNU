using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab1.Models
{
    public class DBContext : DbContext
    {
        public DBContext() : base("DbContext")
        { }

        public DbSet<Auto> Autos { get; set; }
    }
}
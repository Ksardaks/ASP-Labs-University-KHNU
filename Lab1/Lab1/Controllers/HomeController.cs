using Lab1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DBContext Context = new DBContext();
            return View(Context.Products.ToList());
        }

        [HttpGet]
        public ActionResult Buy(int Id)
        {
            DBContext Context = new DBContext();
            return View(Context.Products.Find(Id));
        }

        [HttpPost]
        public ActionResult Buy(int Id, int Count, string PIB, string Address, string Phone)
        {
            DBContext Context = new DBContext();

            Order NewOrder = new Order() { PIB = PIB, Address = Address, Phone = Phone, ProductNumber = Count };
            NewOrder.Product = Context.Products.Find(Id);
            Context.Orders.Add(NewOrder);
            Context.SaveChanges();

            return RedirectToAction("Thanks");
        }

        public ActionResult Thanks()
        {
            return View();
        }
    }
}
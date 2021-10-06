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
            return View(Context.Autos.ToList());
        }

        public ActionResult Auto(int Id)
        {
            DBContext Context = new DBContext();
            return View(Context.Autos.Find(Id));
        }
    }
}
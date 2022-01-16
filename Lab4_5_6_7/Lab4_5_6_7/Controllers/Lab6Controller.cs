using Lab4_5_6_7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Lab4_5_6_7.Controllers
{
    public class Lab6Controller : Controller
    {
        // GET: Lab4
        public ActionResult Index()
        {
            
            ApplicationDbContext Context = new ApplicationDbContext();
            return View(Context.Products.ToList());
        }
    }
}
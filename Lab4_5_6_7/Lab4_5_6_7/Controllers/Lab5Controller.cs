using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab4_5_6_7.Models;

namespace Lab4_5_6_7.Controllers
{
    public class Lab5Controller : Controller
    {
        // GET: Lab5
        public ActionResult Index()
        {
           
            return View(new Validation());
        }

        public ActionResult Success()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Validation model)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }
            
            return View(model);
        }
    }
}
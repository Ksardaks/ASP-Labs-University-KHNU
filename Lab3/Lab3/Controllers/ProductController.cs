using Lab3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab3.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Table()
        {
            DBContext Context = new DBContext();
            return View(Context.Products.ToList());
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string Name, string Desc, double Price, HttpPostedFileBase File)
        {
            DBContext Context = new DBContext();
            Product NewProduct = new Product() { ProductName = Name, Description = Desc, Price = Price};
            string FileName = "NoImage.png";
            
            if(File != null)
            {
                int ProductId = Context.Products.Count() == 0 ? 1 : Context.Products.ToList().Last().Id;
                FileName = "Product" + ProductId + "File" + File.FileName;

                File.SaveAs(Server.MapPath("~/File/" + FileName));
            }

            NewProduct.File = FileName;

            Context.Products.Add(NewProduct);
            Context.SaveChanges();

            return RedirectToAction("Table");
        }

        public ActionResult Edit(int Id)
        {
            DBContext Context = new DBContext();
            return View(Context.Products.Find(Id));
        }

        [HttpPost]
        public ActionResult Edit(int Id, string Name, string Desc, double Price, HttpPostedFileBase File)
        {
            DBContext Context = new DBContext();
            Product EditedProduct = Context.Products.Find(Id);

            EditedProduct.ProductName = Name;
            EditedProduct.Description = Desc;
            EditedProduct.Price = Price;

            string FileName = EditedProduct.File;
            if (File != null)
            {
                if(FileName != "NoImage.png" && System.IO.File.Exists(Server.MapPath("~/File/" + FileName)))
                {
                    System.IO.File.Delete(Server.MapPath("~/File/" + FileName));
                }

                int ProductId = Context.Products.Count() == 0 ? 1 : Context.Products.ToList().Last().Id;
                FileName = "Product" + ProductId + "File" + File.FileName;

                File.SaveAs(Server.MapPath("~/File/" + FileName));
            }

            EditedProduct.File = FileName;

            Context.SaveChanges();

            return RedirectToAction("Table");
        }

        public ActionResult Delete(int Id)
        {
            DBContext Context = new DBContext();
            return View(Context.Products.Find(Id));
        }

        public ActionResult Confirm(int Id)
        {
            DBContext Context = new DBContext();
            Product DeletedProduct = Context.Products.Find(Id);

            if (DeletedProduct.File != "NoImage.png" && System.IO.File.Exists(Server.MapPath("~/File/" + DeletedProduct.File)))
            {
                System.IO.File.Delete(Server.MapPath("~/File/" + DeletedProduct.File));
            }

            Context.Products.Remove(DeletedProduct);

            Context.SaveChanges();

            return RedirectToAction("Table");
        }
    }
}
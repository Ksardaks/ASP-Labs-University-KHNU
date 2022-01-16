using Lab4_5_6_7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4_5_6_7.Controllers
{
    public class Lab4Controller : Controller
    {
        // GET: Lab4
        public ActionResult Index()
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            return View(Context.Products.ToList());
        }

        [HttpGet]
        public ActionResult Buy(int Id)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            return View(Context.Products.Find(Id));
        }

        [HttpPost]
        public ActionResult Buy(int Id, int Count, string PIB, string Address, string Phone)
        {
            ApplicationDbContext Context = new ApplicationDbContext();

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

        public ActionResult ProductTable()
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            return View(Context.Products.ToList());
        }

        public ActionResult CategoryTable()
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            return View(Context.Categories.ToList());
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Category()
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            return PartialView(Context.Categories.ToList());
        }

        [HttpPost]
        public ActionResult Add(string name, string description, List<int> categories, double price, HttpPostedFileBase file)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            Product NewProduct = new Product() { ProductName = name, Price = price };
            string FileName = "NoImage.png";

            if(categories != null)
            {
                foreach(var categoryId in categories)
                {
                    NewProduct.Categories.Add(Context.Categories.Find(categoryId));
                }
            }

            if (file != null)
            {
                int ProductId = Context.Products.Count() == 0 ? 1 : Context.Products.ToList().Last().Id;
                FileName = "Product" + ProductId + "File" + file.FileName;

                file.SaveAs(Server.MapPath("~/File/" + FileName));
            }

            NewProduct.File = FileName;

            Context.Products.Add(NewProduct);
            Context.SaveChanges();

            return RedirectToAction("ProductTable");
        }

        public ActionResult Edit(int Id)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            return View(Context.Products.Find(Id));
        }

        [HttpPost]
        public ActionResult Edit(int Id, string Name, List<int> categories, double Price, HttpPostedFileBase File)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            Product EditedProduct = Context.Products.Find(Id);

            EditedProduct.ProductName = Name;
            if (categories != null)
            {
                foreach (var categoryId in categories)
                {
                    EditedProduct.Categories.Add(Context.Categories.Find(categoryId));
                }
            }
            EditedProduct.Price = Price;

            string FileName = EditedProduct.File;
            if (File != null)
            {
                if (FileName != "NoImage.png" && System.IO.File.Exists(Server.MapPath("~/File/" + FileName)))
                {
                    System.IO.File.Delete(Server.MapPath("~/File/" + FileName));
                }

                int ProductId = Context.Products.Count() == 0 ? 1 : Context.Products.ToList().Last().Id;
                FileName = "Product" + ProductId + "File" + File.FileName;

                File.SaveAs(Server.MapPath("~/File/" + FileName));
            }

            EditedProduct.File = FileName;

            Context.SaveChanges();

            return RedirectToAction("ProductTable");
        }

        public ActionResult Delete(int Id)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            return View(Context.Products.Find(Id));
        }

        public ActionResult Confirm(int Id)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            Product DeletedProduct = Context.Products.Find(Id);

            if (DeletedProduct.File != "NoImage.png" && System.IO.File.Exists(Server.MapPath("~/File/" + DeletedProduct.File)))
            {
                System.IO.File.Delete(Server.MapPath("~/File/" + DeletedProduct.File));
            }

            Context.Products.Remove(DeletedProduct);

            Context.SaveChanges();

            return RedirectToAction("ProductTable");
        }

        public ActionResult CatAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CatAdd(string name)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            Category NewCategory = new Category() { CategoryName = name};

            Context.Categories.Add(NewCategory);
            Context.SaveChanges();

            return RedirectToAction("CategoryTable");
        }

        public ActionResult CatEdit(int Id)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            return View(Context.Categories.Find(Id));
        }

        [HttpPost]
        public ActionResult CatEdit(int Id, string Name)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            Category EditedCategory = Context.Categories.Find(Id);

            EditedCategory.CategoryName = Name;

            Context.SaveChanges();

            return RedirectToAction("CategoryTable");
        }

        public ActionResult CatDelete(int Id)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            return View(Context.Categories.Find(Id));
        }

        public ActionResult CatConfirm(int Id)
        {
            ApplicationDbContext Context = new ApplicationDbContext();
            Category DeletedCategory = Context.Categories.Find(Id);

            Context.Categories.Remove(DeletedCategory);

            Context.SaveChanges();

            return RedirectToAction("CategoryTable");
        }
    }
}
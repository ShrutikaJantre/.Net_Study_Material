using Bookidprogram.Databse;
using Bookidprogram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookidprogram.Controllers
{
    public class ProductController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            List<Product> list = Product.GetAllproducts();

            return View(list);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Product  p)
        {
            try
            {
                Product.InsertProduct(p);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            Product p = Product.Getsingleproduct(id);
            List<SelectListItem> objDepts = new List<SelectListItem>();
            List<Categories> list = Categories.GetAll();
            foreach(var e in list)
            {
                SelectListItem e1 = new SelectListItem();
                e1.Text = e.CategoryName;
                e1.Value = e.CategoryName;
                objDepts.Add(e1);
            }
            p.Categories = objDepts;

            return View(p);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product p)
        {
            
                List<SelectListItem> objDepts = new List<SelectListItem>();
                List<Categories> list = Categories.GetAll();
                foreach (var e in list)
                {
                    SelectListItem e1 = new SelectListItem();
                    e1.Text = e.CategoryName;
                    e1.Value = e.CategoryName;
                    objDepts.Add(e1);
                }
                p.Categories = objDepts;
                Product.UpdateProduct(p);

                return RedirectToAction("Index");
           
           
               // return View();
            
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

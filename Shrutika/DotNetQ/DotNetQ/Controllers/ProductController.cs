using DotNetQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetQ.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            List<Products> prod = Products.GetAllProducts();
      

            return View(prod);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            Products obj = Products.GetSingleProduct(id);
            
            return View(obj);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Products obj)
        {
            try
            {
                // TODO: Add insert logic here
                Products.InsertProduct(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id = 0)
        {
            Products obj = Products.GetSingleProduct(id);

            return View(obj);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id = 0, Products obj = null)
        {
            try
            {
                // TODO: Add update logic here
                Products.UpdateProduct(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id=0)
        {
            Products obj = Products.GetSingleProduct(id);

            return View(obj);
            
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Products.DeleteProduct(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [ChildActionOnly]
        public ActionResult PartialView1()
        {
            return View();

        }
    }
}

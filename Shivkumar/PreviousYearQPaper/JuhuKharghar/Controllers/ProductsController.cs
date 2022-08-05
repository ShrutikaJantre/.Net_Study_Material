using PreviousYearQPaper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PreviousYearQPaper.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<Product> product = Product.GetAllProducts();

            //List<Category> cata = Category.GetAllCatogories();
            //List<SelectListItem> catalist = new List<SelectListItem>();

            //foreach (var item in cata)
            //{
            //    catalist.Add(new SelectListItem { Text = item.CategoryName, Value = item.CategoryId.ToString() });
            //}

            //ViewBag.Categories = catalist;
            return View(product);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            Product product = Product.GetSingleProduct(id);
            List<Category> cata = Category.GetAllCatogories();
            List<SelectListItem> catalist = new List<SelectListItem>();

            foreach (var item in cata)
            {
                catalist.Add(new SelectListItem { Text = item.CategoryName, Value = item.CategoryId.ToString() });
            }

            ViewBag.Categories = catalist;
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
           try
            {
                // TODO: Add update logic here
                Product.UpdateProduct(product);
              return RedirectToAction("Index");
            }
            catch
           {
               return View();
           }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
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

        [ChildActionOnly]
        public ActionResult MyPartialView()
        {
            return View();
        }

    }
}

using ProductTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductTable.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            List<ProductsCLass> list = ProductsCLass.GetAllProducts();
            return View(list);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            ProductsCLass obj = ProductsCLass.GetSingleProduct(id);
            return View(obj);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ProductsCLass p = new ProductsCLass();
            List<SelectListItem> objDepts = new List<SelectListItem>();
            List<Categories> list = Categories.GetAllCategories();
            foreach (var e in list)
            {
                SelectListItem e1 = new SelectListItem();
                e1.Text = e.CategoryName;
                e1.Value = e.CategoryName;
                objDepts.Add(e1);
            }
            p.Category = objDepts;

            return View(p);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductsCLass p)
        {
            try
            {
                // TODO: Add insert logic here
                ProductsCLass.InsertProduct(p);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id=0)
        {
           // ProductsCLass obj = ProductsCLass.GetSingleProduct(id);

            ProductsCLass product = ProductsCLass.GetSingleProduct(id);
            List<Categories> cata = Categories.GetAllCategories();
            List<SelectListItem> catalist = new List<SelectListItem>();

            List<Categories> list = Categories.GetAllCategories();

            foreach (var e in list)
            {
                SelectListItem e1 = new SelectListItem();
                e1.Text = e.CategoryName;
                e1.Value = e.CategoryName;
                catalist.Add(e1);

            }

            product.Category = catalist;
            return View(product);


        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id=0, ProductsCLass obj=null)
        {
            try
            {
                // TODO: Add update logic here
                List<Categories> cata = Categories.GetAllCategories();
                List<SelectListItem> catalist = new List<SelectListItem>();

                List<Categories> list = Categories.GetAllCategories();

                foreach (var e in list)
                {
                    SelectListItem e1 = new SelectListItem();
                    e1.Text = e.CategoryName;
                    e1.Value = e.CategoryId.ToString();
                    catalist.Add(e1);

                }

                obj.Category = catalist;
                ProductsCLass.UpdateProduct(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
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
        public ActionResult PartialView1()
        {
            return View();
        }
    }
}

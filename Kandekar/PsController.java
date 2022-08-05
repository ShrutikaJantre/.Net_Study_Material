using PMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMvc.Controllers
{
    public class PsController : Controller
    {
        // GET: Ps
        public ActionResult Index()
        {
            List<P> plist = P.GetAllP();

            

            return View(plist);
        }

        // GET: Ps/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ps/Create
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

        // GET: Ps/Edit/5
        public ActionResult Edit(int id)
        {
           P p = P.GetSingleP(id);
            return View(p);
        }

        // POST: Ps/Edit/5
        [HttpPost]
        public ActionResult Edit( P p)
        {
            try
            {
                P.UpdateP(p);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ps/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ps/Delete/5
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

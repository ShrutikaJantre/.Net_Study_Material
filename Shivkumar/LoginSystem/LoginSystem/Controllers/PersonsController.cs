using LoginSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginSystem.Controllers
{
    public class PersonsController : Controller
    {
        // GET: Persons
        public ActionResult Index()
        {
            return View();
        }

        // GET: Persons/Details/5
        public ActionResult Details()
        {
            string name = (string)Session["LoggedPerson"];
            Person person = Person.GetSinglePerson(name);
            return View(person);
        }


        [HttpPost]
        public ActionResult Details(string logout)
        {
            if (!string.IsNullOrEmpty(logout))
            {
                return RedirectToAction("Logout");
            }
            string name = (string)Session["LoggedPerson"];
            Person obj = Person.GetSinglePerson(name);
            return View(obj);

        }


        // GET: Persons/Create
        public ActionResult Create()

        {
            List<City> cities = City.GetAllCities();
            List<SelectListItem> objCity = new List<SelectListItem>();
            foreach (var item in cities)
            {
                objCity.Add(new SelectListItem { Text=item.CityName, Value=item.CityId.ToString()});
            }
            ViewBag.Cities = objCity;
            return View();
        }

        // POST: Persons/Create
        [HttpPost]
        public ActionResult Create(Person obj)
        {
            try
            {
                // TODO: Add insert logic here

                Person.InsertPersons(obj);

                return RedirectToAction("Login");
            }
            catch
            {
                return RedirectToAction("Create");
            }
        }

        // GET: Persons/Edit/5
        public ActionResult Edit(string id)
        {           
            Person person = Person.GetSinglePerson(id);
            List<City> cities = City.GetAllCities();
            List<SelectListItem> objCity = new List<SelectListItem>();
            foreach (var item in cities)
            {
                objCity.Add(new SelectListItem { Text = item.CityName, Value = item.CityId.ToString() });
            }
            ViewBag.Cities = objCity;
            return View(person);
        }

        // POST: Persons/Edit/5
        [HttpPost]
        public ActionResult Edit(Person obj)
        {
            try
            {
                // TODO: Add update logic here
                Person.UpdatePerson(obj);
                return RedirectToAction("Details");
            }
            catch
            {
                return View();
            }
        }

        // GET: Persons/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Persons/Delete/5
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

        //===============================================================

       

        // GET: Persons/Login
        public ActionResult Login()
        {
            HttpCookie objCookie = Request.Cookies["PersonLogin"];
            if (objCookie == null)
            {

                return View();
            }
            else
            {
                
                Session["LoggedPerson"] = objCookie.Value;
                return RedirectToAction("Details");
            }

           

        }

        // POST: Persons/Login
        [HttpPost]
        public ActionResult Login(Person obj)
        {
            try
            {
                // TODO: Add insert logic here

                bool isValidPerson = Person.IsValidPerson(obj);

                if (isValidPerson)
                {
                    if (obj.isActive)
                    {
                        HttpCookie objCookie = new HttpCookie("PersonLogin");
                        objCookie.Expires = DateTime.Now.AddDays(1);
                        objCookie.Value = obj.LoginName;
                        Response.Cookies.Add(objCookie);
                        
                    }
                    Session["LoggedPerson"] = obj.LoginName;
                    return RedirectToAction("Details");
                }
                else
                {
                    return RedirectToAction("Login");
                }
                
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Logout()
        {
            Session.Abandon();
            HttpCookie objCookie = new HttpCookie("PersonLogin");
            objCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(objCookie);

            return RedirectToAction("Login");
        }

        [ChildActionOnly]
        public ActionResult PartialView1()
        {
            return View();
        }
    }
}

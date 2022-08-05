using EmpAppWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpAppWebMvc.Controllers
{
    public class PersonsController : Controller
    {
        public ActionResult Login()
        {
            HttpCookie objCookie = Request.Cookies["ChocoChip"];
            if (objCookie == null)
            {
                return View();
            }
            else
            {
                Session["Name"] = objCookie.Values["key1"];
                return RedirectToAction("Details");
               
            }
        }

        [HttpPost]
        public ActionResult Login(Person p, string RememberMe)
        {
           
            try
            {
    
                    // TODO: Add insert logic here
                    bool valid = Person.isValid(p);
                    if (valid)
                    {
                        
                            if (p.isActive)
                                Response.Cookies.Add(Person.CreateCookie(p));
                                Session["Name"] = p.LoginName;
                                

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



        // GET: Persons
        public ActionResult Index()
        {
            Person p = new Person();
            p.LoginName = "Sk";
            p.EmailId = "Sk@gmail.com";
            p.CityId = 10;
            p.FullName = "shubham";
            p.Phone = 4785560;
            p.Password = "Sk123";

            List<Person> list = new List<Person>();
            list.Add(p);
           
            return View(list);
        }

        // GET: Persons/Details/5
        public ActionResult Details(string LoginName)
        {
            string Name = (string)Session["Name"];
            Person p = Person.GetSinglePerson(Name);
            return View(p);
        }

        // GET: Persons/Create
        public ActionResult Create()
        {
            List<City> list = City.GetAllCity();
            List<SelectListItem> city = new List<SelectListItem>();

            foreach (var item in list)
            {
               city.Add(new SelectListItem { Text = item.CityName, Value = item.CityId.ToString() });
            }

            ViewBag.Cities = city;
            return View();
        }

        // POST: Persons/Create
        [HttpPost]
        public ActionResult Create(Person p)
        {
            try
            {
                Person.InsertPerson(p);
                // TODO: Add insert logic here

                return RedirectToAction("Login");
            }
            catch
            {
                return View();
            }
        }

        // GET: Persons/Edit/5
        public ActionResult Edit(string id)
        {
            //string Name = (string)Session["Name"];
            Person p = Person.GetSinglePerson(id);

            List<City> list = City.GetAllCity();
            List<SelectListItem> city = new List<SelectListItem>();

            foreach (var item in list)
            {
                city.Add(new SelectListItem { Text = item.CityName, Value = item.CityId.ToString() });
            }

            ViewBag.Cities = city;
            return View(p);
        }

        // POST: Persons/Edit/5
        [HttpPost]
        public ActionResult Edit( Person p)
        {
            try
            {
                
                    Person.UpdatePerson(p);
                    return RedirectToAction("Details");
                
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Logout()
        {
            Session.Abandon();
            HttpCookie objCookie = new HttpCookie("ChocoChip");

            objCookie.Expires = DateTime.Now.AddDays(-1);

            Response.Cookies.Add(objCookie);
            return RedirectToAction("Login");
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
    }
}

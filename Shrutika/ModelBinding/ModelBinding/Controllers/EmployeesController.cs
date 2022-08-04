using ModelBinding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBinding.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            //List<Employee> emps = new List<Employee>();
            //emps.Add(new Employee { EmpNo = 1, Name = "Shrutika", Basic = 10000, DeptNo = 20 });
            //emps.Add(new Employee { EmpNo = 2, Name = "Himanshu", Basic = 10000, DeptNo = 20 });
            //emps.Add(new Employee { EmpNo = 3, Name = "Gopal", Basic = 10000, DeptNo = 20 });
            //emps.Add(new Employee { EmpNo = 4, Name = "Bediskar", Basic = 10000, DeptNo = 20 });
            List<Employee> emps = Employee.GetAllEmployees();
            return View(emps);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id = 0)
        {
            //Employee obj = new Employee();
            //obj.EmpNo = id;
            //obj.Name = "Himanshu";
            //obj.Basic = 12345;
            //obj.DeptNo = 10;

            Employee obj = Employee.GetSingleEmployee(id);
            return View(obj);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Employee obj)
        {
            try
            {
                // TODO: Add insert logic here
                Employee.InsertEmployee(obj);
                return RedirectToAction("Index");
                
            }
            catch(Exception x)
            {
                ViewBag.message = x.Message;
                return View();
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id = 0)
        {
            //Employee obj = new Employee();
            //obj.EmpNo = id;
            //obj.Name = "Himanshu";
            //obj.Basic = 12345;
            //obj.DeptNo = 10;

            Employee obj = Employee.GetSingleEmployee(id);
            return View(obj);

        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int id = 0, Employee obj = null)
        {
            try
            {
                // TODO: Add update logic here

                Employee.UpdateEmployee(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id = 0)
        {
            //Employee obj = new Employee();
            //obj.EmpNo = id;
            //obj.Name = "Himanshu";
            //obj.Basic = 12345;
            //obj.DeptNo = 10;

            Employee obj = Employee.GetSingleEmployee(id);
            return View(obj);
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id = 0, Employee obj = null)
        {
            try
            {
                // TODO: Add delete logic here

                Employee.DeleteEmployee(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

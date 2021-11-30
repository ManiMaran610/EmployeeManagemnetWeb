using EmployeeManagemnetWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagemnetWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddEmployee(Employee employee)

        {
            return View(employee);
        }


        public ActionResult EditEmployee(Employee employee)
        {

            return View(employee);
        }




        public ActionResult ViewEmployee()
        {
            using (var context = new EmployeeContext())
            {

                List<Employee> model = context.Employees.ToList();

                return View(model);
            }
        }


        public ActionResult AddtoDb(Employee employee)
        {
            using (var context = new EmployeeContext())
            {
              
                var IsValid = context.Employees.ToList().Exists(item => item.EmployeeID == employee.EmployeeID);
                if (!IsValid && ModelState.IsValid)
                {
                    employee.EmployeeID = employee.EmployeeID.ToUpper();
                    context.Employees.Add(employee);
                    context.SaveChanges();
                    return View("Onsuccess");
                    
                }
                else 
                {
                    if(IsValid) 
                       ViewBag.AlreadyExistsErrorMessage = $"Employee ID already exists in the database";
                    return RedirectToAction("addemployee", employee);

                }
            }
        }

        public ActionResult OnSuccess(string AddorUpdate)
        {
            ViewBag.AddorUpdate = AddorUpdate;
            return View();
        }

        public ActionResult EditToDb(Employee employee)
        {
           
            employee.EmployeeID = employee.EmployeeID.ToUpper();

            using (var context = new EmployeeContext())
            {
             
                if (ModelState.IsValid)
                {
                    context.Entry(employee).State = EntityState.Modified;
                    context.SaveChanges();
                    return View("OnSuccess");
                }
                //context.Employees.AddOrUpdate(employee);
                //    context.SaveChanges();
                return RedirectToAction("EditEmployee");
            }
        }
        public ActionResult DeleteEmployee(Employee employee)
        {
            using (var context = new EmployeeContext())
            {
                var employ = context.Employees.Where(d => d.EmployeeID == employee.EmployeeID).First();
                context.Employees.Remove(employ);
                context.SaveChanges();
                return RedirectToAction("ViewEmployee");
            }
        }
    }
}
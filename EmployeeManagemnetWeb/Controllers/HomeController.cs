using EmployeeManagemnetWeb.Models;
using System;
using System.Collections.Generic;
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
            ViewBag.action = "AddToDb";
           
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
                if (IsValid)
                {
                    ViewBag.AlreadyExistsErrorMessage = $"Employee ID already exists in the database";
                    return View("addemployee", employee);
                }
                else
                {
                    context.Employees.Add(employee);
                    context.SaveChanges();
                    return View(employee);
                }
            }
        }

            public ActionResult EditToDb(Employee employee)
            {
                using (var context = new EmployeeContext())
                {
                    
                    var IsValid = context.Employees.ToList().Exists(item => item.EmployeeID == employee.EmployeeID);
                    if (IsValid)
                    {
                    context.Employees.AddOrUpdate(employee);
                    context.SaveChanges();
                    return View("AddtoDb",employee);
                    
                    }
                    else
                    {
                    ViewBag.AlreadyExistsErrorMessage = $"Employee ID doesn't exists in the database";
                    return View("EditEmployee", employee);
                }
                }
            }
    }
}
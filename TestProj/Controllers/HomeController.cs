using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProj.Models;

namespace TestProj.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            var model = new Employee()
            {
                Cities = GetCities(),
                States = GetStates(),
            };
            var students = Session["Employees"] as List<EmployeeData>;
            model.Employees = students ?? new List<EmployeeData>();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(Employee emp)
        {
            var students = Session["Employees"] as List<EmployeeData>;
            if (students == null)
            {
                students = new List<EmployeeData>();
            }
            var empId = students.Count > 0 ?students.Max(x => x.EmployeeID) : 0;
            students.Add(new EmployeeData()
            {
                EmployeeID = empId + 1,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                Gender = emp.Gender,
                City = emp.City,
                State = emp.State

            });

            Session["Employees"] = students;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditModal(Employee emp)
        {
            
            var students = Session["Employees"] as List<EmployeeData>;
            
                var student = students.Where(s => s.EmployeeID == emp.EmployeeID).FirstOrDefault();
                if (student != null)
                {
                
                student.FirstName = emp.FirstName;
                student.LastName = emp.LastName;
                student.Gender = emp.Gender;
                student.City = emp.City;
                student.State = emp.State;
                };
            

            
            Session["Employees"] = students;
            return RedirectToAction("Index");
        }

        public ActionResult EditModal(int id)
        {
            var model = new Employee()
            {
                Cities = GetCities(),
                States = GetStates(),
            };

            var students = Session["Employees"] as List<EmployeeData>;
            if(students != null)
            {
                var student = students.Where(s => s.EmployeeID == id).FirstOrDefault();
                if(student != null)
                {
                    model.EmployeeID = student.EmployeeID;
                    model.FirstName = student.FirstName;
                    model.LastName = student.LastName;
                    model.Gender = student.Gender;
                    model.City = student.City;
                    model.State = student.State;
                };
            }
            
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Delete(Employee emp)
        {
            var students = Session["Employees"] as List<EmployeeData>;
            students.Remove( students.Where(s => s.EmployeeID == emp.EmployeeID).FirstOrDefault());
            Session["Employees"] = students;
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var model = new Employee();
            model.EmployeeID = id;
            return PartialView(model);
        }
      

        private SelectList GetCities()
        {
            List<SelectListItem> lst = new List<SelectListItem>();

            var cityname1 = new SelectListItem()
            {
                Text = "Los Angeles",
                Value = "LA"
            };
            var cityname2 = new SelectListItem()
            {
                Text = "Clevland",
                Value = "CLA"
            };

            lst.Add(cityname1);
            lst.Add(cityname2);

            return new SelectList(lst, "Value", "Text");
        }


        private SelectList GetStates()
        {
            List<SelectListItem> lst = new List<SelectListItem>();

            var state1 = new SelectListItem()
            {
                Text = "California",
                Value = "CA"
            };
            var state2 = new SelectListItem()
            {
                Text = "Ohio",
                Value = "OH"
            };

            lst.Add(state1);
            lst.Add(state2);

            return new SelectList(lst, "Value", "Text");
        }

    }
}
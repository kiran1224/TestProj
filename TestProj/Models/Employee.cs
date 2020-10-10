using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestProj.Models
{
    public class Employee
    {
        public SelectList Cities { get; set; }
        public SelectList States { get; set; }
        public List<EmployeeData> Employees { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int EmployeeID { get; set; }


    }
}
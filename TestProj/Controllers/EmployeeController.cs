using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestProj.Controllers
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {


        [HttpGet]
        [Route("countries")]
        public List<string> country()
        {
            var lines = System.IO.File.ReadAllLines(@"C:\Code\country.txt");

            List<string> Final = new List<string>();

            foreach (var item in lines)
            {
                var countries = item.Split(',');
                foreach (var d in countries)
                {
                    Final.Add(d);
                }

            }
            return Final;


        }
        


    }
}

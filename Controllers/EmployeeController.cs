using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPM.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult EmployeeRegistration()
        {
            return View();
        }

        public IActionResult RecordAttendance()
        {
            return View();
        }

        public IActionResult ShowAnnc()
        {
            return View();
        }

        public IActionResult GetSalaryInfo()
        {
            return View();
        }
    }
}

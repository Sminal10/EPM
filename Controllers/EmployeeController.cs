﻿using Microsoft.AspNetCore.Mvc;
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

    }
}
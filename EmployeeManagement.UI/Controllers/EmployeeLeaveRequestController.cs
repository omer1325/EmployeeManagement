using EmployeeManagement.BusinessEngine.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.UI.Controllers
{
    public class EmployeeLeaveRequestController : Controller
    {
        private readonly IEmployeeLeaveRequestEngine _employeeLeaveRequestEngine;

        public EmployeeLeaveRequestController(IEmployeeLeaveRequestEngine employeeLeaveRequestEngine)
        {
            _employeeLeaveRequestEngine = employeeLeaveRequestEngine;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

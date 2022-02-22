using EmployeeManagement.BusinessEngine.Contracts;
using EmployeeManagement.Common.ConstantModels;
using EmployeeManagement.Common.SessionOperations;
using EmployeeManagement.Common.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmployeeManagement.UI.Controllers
{
    public class EmployeeLeaveRequestController : Controller
    {
        private readonly IEmployeeLeaveRequestBusinessEngine _employeeLeaveRequestBusinessEngine;
        private readonly IEmployeeLeaveTypeBusinessEngine _employeeLeaveTypeBusinessEngine;

        public EmployeeLeaveRequestController(IEmployeeLeaveRequestBusinessEngine employeeLeaveRequestBusinessEngine, IEmployeeLeaveTypeBusinessEngine employeeLeaveTypeBusinessEngine)
        {
            _employeeLeaveRequestBusinessEngine = employeeLeaveRequestBusinessEngine;
            _employeeLeaveTypeBusinessEngine = employeeLeaveTypeBusinessEngine;
        }

        public IActionResult Index()
        {
            var employee = JsonConvert.DeserializeObject<SessionContext>(HttpContext.Session.GetString(Constant.LoginUserInfo));
            var requestModel = _employeeLeaveRequestBusinessEngine.GetAllLeaveRequestByUserId(employee.LoginId);

            ViewBag.EmployeeLeaveTypes = _employeeLeaveTypeBusinessEngine.GetAllEmployeeLeaveTypes();
            if (requestModel.IsSuccess)
            {
                return View(requestModel.Data);
            }
            return View(employee);

        }

        public IActionResult Create()
        {
            ViewBag.EmployeeLeaveTypes = _employeeLeaveTypeBusinessEngine.GetAllEmployeeLeaveTypes().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeLeaveRequestVM employeeLeaveRequestVM, int? id)
        {
            
                var employee = JsonConvert.DeserializeObject<SessionContext>(HttpContext.Session.GetString(Constant.LoginUserInfo));
                if (id> 0)
                {
                    var data = _employeeLeaveRequestBusinessEngine.EditEmployeeLeaveRequest(employeeLeaveRequestVM, employee);
                    return RedirectToAction("Index");
                }
                else
                {
                    var data = _employeeLeaveRequestBusinessEngine.CreateEmployeeLeaveRequest(employeeLeaveRequestVM, employee);
                    if (data.IsSuccess)
                    {
                        return RedirectToAction("Index");
                    }
                    return View();
                }            
        }

        public IActionResult Edit(int? id)
        {
            ViewBag.EmployeeLeaveTypes = _employeeLeaveTypeBusinessEngine.GetAllEmployeeLeaveTypes().Data;
            if (id > 0)
            {
                var data = _employeeLeaveRequestBusinessEngine.GetAllLeaveRequestById((int)id);
                return View(data.Data);
            }
            else
            {
                return View();
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return Json(new { success = false, message = Constant.RecordDeleteNotBeEmpty });
            }

            var data = _employeeLeaveRequestBusinessEngine.RemoveEmployeeLeaveRequest(id);

            if (data.IsSuccess)
            {
                return Json(new { success = data.IsSuccess, message = data.Message });
            }
            else
            {
                return Json(new { success = data.IsSuccess, message = data.Message });
            }
        }

        public ActionResult Reject(int id)
        {
            if (id > 0)
            {
                var data = _employeeLeaveRequestBusinessEngine.RejectEmployeeLeaveRequest((int)id);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}

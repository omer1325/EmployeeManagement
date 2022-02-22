using EmployeeManagement.BusinessEngine.Contracts;
using EmployeeManagement.Common.ConstantModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.UI.Controllers
{
    [Authorize(Roles = Constant.Admin_Role)]
    public class EmployeeLeaveAllocationController : Controller
    {
        #region Variables
        private readonly IEmployeeLeaveAllocationBusinessEngine _employeeLeaveAllocationBusinessEngine;
        private readonly IEmployeeLeaveRequestBusinessEngine _employeeLeaveRequestBusinessEngine;
        #endregion

        #region Constructor
        public EmployeeLeaveAllocationController(IEmployeeLeaveAllocationBusinessEngine employeeLeaveAllocationBusinessEngine, IEmployeeLeaveRequestBusinessEngine employeeLeaveRequestBusinessEngine)
        {
            _employeeLeaveAllocationBusinessEngine = employeeLeaveAllocationBusinessEngine;
            _employeeLeaveRequestBusinessEngine = employeeLeaveRequestBusinessEngine;
        } 
        #endregion

        public IActionResult Index()
        {
            var data = _employeeLeaveRequestBusinessEngine.GetSenApprovedLeaveRequests();
            if (data.IsSuccess)
            {
                return View(data.Data);
            }
            return View();
        }

        public IActionResult Approved(int id)
        {
            if (id <= 0)
            {
                return Json(new { success = false, message = "Onaylamak İçin Kayıt Seçiniz" });
            }

            var data = _employeeLeaveAllocationBusinessEngine.ApprovedEmployeeLeaveRequest(id);
            if (data.IsSuccess)
            {
                return Json(new { success = data.IsSuccess, message = data.Message });
            }
            else
            {
                return Json(new { success = data.IsSuccess, message = data.Message });
            }
        }
    }
}

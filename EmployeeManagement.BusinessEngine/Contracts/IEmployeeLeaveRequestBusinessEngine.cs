using EmployeeManagement.BusinessEngine.ResultModels;
using EmployeeManagement.Common.SessionOperations;
using EmployeeManagement.Common.ViewModels;
using System.Collections.Generic;

namespace EmployeeManagement.BusinessEngine.Contracts
{
    public interface IEmployeeLeaveRequestBusinessEngine
    {
        Result<List<EmployeeLeaveRequestVM>> GetAllLeaveRequestByUserId(string emploeeId);
        Result<EmployeeLeaveRequestVM> CreateEmployeeLeaveRequest(EmployeeLeaveRequestVM employeeLeaveRequestVM, SessionContext employee);
        Result<EmployeeLeaveRequestVM> EditEmployeeLeaveRequest(EmployeeLeaveRequestVM employeeLeaveRequestVM, SessionContext employee);
        Result<EmployeeLeaveRequestVM> GetAllLeaveRequestById(int id);
        Result<EmployeeLeaveRequestVM> RemoveEmployeeLeaveRequest(int id);
        Result<List<EmployeeLeaveRequestVM>> GetSenApprovedLeaveRequests();
        Result<bool> RejectEmployeeLeaveRequest(int id);

    }
}

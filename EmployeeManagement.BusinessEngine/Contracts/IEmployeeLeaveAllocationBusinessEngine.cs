using EmployeeManagement.BusinessEngine.ResultModels;

namespace EmployeeManagement.BusinessEngine.Contracts
{
    public interface IEmployeeLeaveAllocationBusinessEngine
    {
        Result<bool> ApprovedEmployeeLeaveRequest(int id);
    }
}
